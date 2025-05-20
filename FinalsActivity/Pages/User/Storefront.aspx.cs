using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FinalsActivity.Pages.User
{
    public partial class Storefront : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindProducts();
            }
        }

        private void BindProducts()
        {
            string connStr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|MainDatabase.mdf;Integrated Security=True";
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
            if (e.CommandName == "Select")
            {
                string selectedProductId = e.CommandArgument.ToString();

                // Show the quantity and total panel
                Panel pnl = (Panel)e.Item.FindControl("pnlSelection");
                pnl.Visible = true;

                // You could also load price from database here if needed and display total price
                // Or store product info in ViewState or Session
            }
        }
    }
}