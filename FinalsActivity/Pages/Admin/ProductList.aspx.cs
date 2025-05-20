using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FinalsActivity.Pages.Admin
{
    public partial class ProductList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                BindProductGrid();
            }

        }

        private void BindProductGrid()
        {
            string connStr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|MainDatabase.mdf;Integrated Security=True";

            using (SqlConnection conn = new SqlConnection(connStr))
            using (SqlCommand cmd = new SqlCommand("GetProductList", conn))
            {

                cmd.CommandType = CommandType.StoredProcedure;

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                grdUserList.DataSource = reader;
                grdUserList.DataBind();

            }
        }

        protected void btnAddProduct_Click(object sender, EventArgs e)
        {
            string connStr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|MainDatabase.mdf;Integrated Security=True";

            using (SqlConnection conn = new SqlConnection(connStr))
            using (SqlCommand cmd = new SqlCommand("AddNewProduct", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@ProductID", txtProductID.Text.Trim());
                cmd.Parameters.AddWithValue("@ProductName", txtProductName.Text.Trim());
                cmd.Parameters.AddWithValue("@Price", decimal.Parse(txtPrice.Text.Trim()));
                cmd.Parameters.AddWithValue("@Stocks", int.Parse(txtStocks.Text.Trim()));

                conn.Open();
                cmd.ExecuteNonQuery();
            }

            txtProductID.Text = "";
            txtProductName.Text = "";
            txtPrice.Text = "";
            txtStocks.Text = "";

            BindProductGrid();
        }

    }
}