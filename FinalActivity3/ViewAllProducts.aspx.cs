using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataHelper;

namespace FinalActivity3
{
    public partial class AdminDashboard : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                LoadGridData();
            }

        }

        DataAccess db = new DataAccess();
    

        string connStr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\chloe\Source\Repos\ITCS227LAB-finals\FinalActivity3\App_Data\MAINDB.mdf;Integrated Security=True";

        private void LoadGridData()
        {

            using (SqlConnection conn = new SqlConnection(connStr))
            {

                using (SqlCommand cmd = new SqlCommand("GetProductList", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    GridView1.DataSource = dt;
                    GridView1.DataBind();
                }

            }

        }

        protected void btnAddProduct_Click(object sender, EventArgs e)
        {

            decimal price, srp;
            int stocks;

            if (decimal.TryParse(txtPrice.Text, out price) &&
                decimal.TryParse(txtSRP.Text, out srp) &&
                int.TryParse(txtStocks.Text, out stocks))
            {
                bool success = db.AddProduct(txtProductID.Text, txtProductName.Text, price, stocks, srp);
                if (success)
                {
                    


                }
                else
                {
                    Response.Write("Registration failed. Try again.");
                }
            }
            else
            {
                Response.Write("Invalid numeric values entered.");
            }

        }
    }
}