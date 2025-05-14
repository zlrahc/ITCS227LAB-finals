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
        protected void btnUpload_Click(object sender, EventArgs e)
        {

            

        }

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

            bool success = db.AddProduct(Convert.ToInt32(txtID.Text), txtProductID.Text, txtProductName.Text,Convert.ToDecimal(txtPrice.Text), Convert.ToInt32(txtStocks.Text), Convert.ToDecimal(txtSRP.Text));
            if (success)
            {
                Response.Redirect("Login.aspx");
            }
            else
            {
                Response.Write("Registration failed. Try again.");
            }

        }
    }
}