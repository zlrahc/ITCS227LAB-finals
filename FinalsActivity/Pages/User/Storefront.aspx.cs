using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.EnterpriseServices.CompensatingResourceManager;
using System.Configuration;

namespace FinalsActivity.Pages.User
{
    public partial class Storefront : System.Web.UI.Page
    {

        private string connStr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|MainDatabase.mdf;Integrated Security=True";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindProducts();
            }
        }

        private void BindProducts()
        {
            
            using (SqlConnection conn = new SqlConnection(connStr))
            using (SqlCommand cmd = new SqlCommand("GetProductList", conn))
            {
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                rptProducts.DataSource = reader;
                rptProducts.DataBind();
            }
        }

        protected void rptProducts_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "AddToCart")
            {
                string ProductID = e.CommandArgument.ToString();
                TextBox txtQuantity = (TextBox)e.Item.FindControl("txtQuantity");

                if (int.TryParse(txtQuantity.Text, out int Quantity) && Quantity > 0)
                {
                    string UserID = Session["UserID"].ToString();

                    AddToCart(UserID, ProductID, Quantity);

                    txtQuantity.Text = "0";

                }
                else
                {
                    //lagyan invalid quantity
                }
            }
        }

        private void AddToCart(string userId, string productId, int quantity)
        {

            using (SqlConnection conn = new SqlConnection(connStr))
            using (SqlCommand cmd = new SqlCommand("AddToCart", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@UserID", userId);
                cmd.Parameters.AddWithValue("@ProductID", productId);
                cmd.Parameters.AddWithValue("@Quantity", quantity);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

    }
}