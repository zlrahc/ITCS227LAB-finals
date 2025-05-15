using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FinalActivity3
{
    public partial class Home : System.Web.UI.Page
    {

        private string connStr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|MAINDB.mdf;Integrated Security=True";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadProducts();
            }

            string productId = Request.QueryString["productId"];
            if (!string.IsNullOrEmpty(productId))
            {
                LoadProductDetails(productId);
            }
        }

        private void LoadProducts()
        {

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                using (SqlCommand cmd = new SqlCommand("GetProductList", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    rptProducts.DataSource = dt;
                    rptProducts.DataBind();
                }
            }
        }

        private void LoadProductDetails(string productId)
        {

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                using (SqlCommand cmd = new SqlCommand("GetProductDetails", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ProductID", productId);

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    if (dt.Rows.Count > 0)
                    {
                        DataRow row = dt.Rows[0];

                        DataTable selectedProducts;
                        if (Session["SelectedProducts"] == null)
                        {
                            selectedProducts = new DataTable();
                            selectedProducts.Columns.Add("ProductName");
                            selectedProducts.Columns.Add("Price");
                        }
                        else
                        {
                            selectedProducts = (DataTable)Session["SelectedProducts"];
                        }

                        DataRow newRow = selectedProducts.NewRow();
                        newRow["ProductName"] = row["ProductName"].ToString();
                        newRow["Price"] = row["Price"].ToString();
                        selectedProducts.Rows.Add(newRow);

                        Session["SelectedProducts"] = selectedProducts;

                        rptSelectedProducts.DataSource = selectedProducts;
                        rptSelectedProducts.DataBind();
                    }
                }
            }
        }

    }
}
