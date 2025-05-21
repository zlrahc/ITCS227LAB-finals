using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataHelper;

namespace FinalsActivity.Pages.User
{

    public partial class ShoppingCart : System.Web.UI.Page
    {

        private string connStr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|MainDatabase.mdf;Integrated Security=True";


        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {

                LoadCart(Session["UserID"].ToString());

            }

        }

        private void LoadCart(string UserID)
        {
            decimal totalAmount = 0;

            using (SqlConnection conn = new SqlConnection(connStr))
            using (SqlCommand cmd = new SqlCommand("GetCartItems", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@UserID", UserID);

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                DataTable dt = new DataTable();
                dt.Load(reader);

                // Compute TotalAmount (assuming 'Total' column is per row: Quantity * Price)
                foreach (DataRow row in dt.Rows)
                {
                    if (decimal.TryParse(row["Total"].ToString(), out decimal itemTotal))
                    {
                        totalAmount += itemTotal;
                    }
                }

                gvCart.DataSource = dt;
                gvCart.DataBind();
            }

            CalculateFinalAmount(totalAmount);
        }

        protected void gvCart_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "DeleteItem")
            {
                int cartId = Convert.ToInt32(e.CommandArgument);
                DeleteCartItem(cartId);
                LoadCart(Session["UserID"].ToString());
            }
        }

        private void DeleteCartItem(int cartId)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            using (SqlCommand cmd = new SqlCommand("DELETE FROM Cart WHERE CartID = @CartID", conn))
            {
                cmd.Parameters.AddWithValue("@CartID", cartId);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }
        private void CalculateFinalAmount(decimal totalAmount)
        {
            string membership = Session["MemberType"]?.ToString();

            decimal finalAmount = Calculation.CalculateTotal(totalAmount, membership);
            decimal vat = Calculation.CalculateVAT(totalAmount);
            decimal discount = Calculation.CalculateDiscount(totalAmount, membership);

            lblSubtotal.Text = totalAmount.ToString("C");
            lblVAT.Text = vat.ToString("C");
            lblDiscount.Text = discount.ToString("C");
            lblFinalAmount.Text = finalAmount.ToString("C");
        }

        protected void btnCheckout_Click(object sender, EventArgs e)
        {
            string UserID = Session["UserID"].ToString();

            string transactionId = Guid.NewGuid().ToString();
            DateTime transactionDate = DateTime.Now;
            decimal totalAmount = 0;

            if (!decimal.TryParse(lblFinalAmount.Text, System.Globalization.NumberStyles.Currency, null, out totalAmount))
                totalAmount = 0;

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                SqlTransaction transaction = conn.BeginTransaction();

                try
                {
                    using (SqlCommand cmd = new SqlCommand("InsertTransactionLog", conn, transaction))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@TransactionID", transactionId);
                        cmd.Parameters.AddWithValue("@UserID", UserID);
                        cmd.Parameters.AddWithValue("@TransactionDate", transactionDate);
                        cmd.Parameters.AddWithValue("@Total", totalAmount);
                        cmd.ExecuteNonQuery();
                    }

                    List<(string DetailsID, string ProductID, int Quantity, decimal Price)> items = new List<(string, string, int, decimal)>();

                    using (SqlCommand cmd = new SqlCommand(
                        @"SELECT c.ProductID, c.Quantity, p.Price
                  FROM Cart c
                  JOIN ProductList p ON c.ProductID = p.ProductID
                  WHERE c.UserID = @UserID", conn, transaction))
                    {
                        cmd.Parameters.AddWithValue("@UserID", UserID);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                string detailsId = Guid.NewGuid().ToString();
                                string productId = reader["ProductID"].ToString();
                                int quantity = Convert.ToInt32(reader["Quantity"]);
                                decimal price = Convert.ToDecimal(reader["Price"]);

                                items.Add((detailsId, productId, quantity, price));
                            }
                        }
                    }

                    foreach (var item in items)
                    {
                        using (SqlCommand cmd = new SqlCommand("InsertTransactionDetails", conn, transaction))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@DetailsID", item.DetailsID);
                            cmd.Parameters.AddWithValue("@TransactionID", transactionId);
                            cmd.Parameters.AddWithValue("@ProductID", item.ProductID);
                            cmd.Parameters.AddWithValue("@Quantity", item.Quantity);
                            cmd.Parameters.AddWithValue("@Price", item.Price);
                            cmd.Parameters.AddWithValue("@Amount", item.Price * item.Quantity);
                            cmd.ExecuteNonQuery();
                        }

                        using (SqlCommand cmd = new SqlCommand("UpdateProductQuantity", conn, transaction))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@ProductID", item.ProductID);
                            cmd.Parameters.AddWithValue("@Quantity", item.Quantity);
                            cmd.ExecuteNonQuery();
                        }
                    }

                    using (SqlCommand cmd = new SqlCommand("ClearCartByUser", conn, transaction))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@UserID", UserID);
                        cmd.ExecuteNonQuery();
                    }

                    transaction.Commit();

                    LoadCart(UserID);

                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    Response.Write("<script>alert('Checkout failed: " + ex.Message.Replace("'", "\\'") + "');</script>");
                }
            }
        }


    }
}