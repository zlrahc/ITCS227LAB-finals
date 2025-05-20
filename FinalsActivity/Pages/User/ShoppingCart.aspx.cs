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

        private void LoadCart(string userId)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            using (SqlCommand cmd = new SqlCommand("GetCartItems", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@UserID", userId);

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                gvCart.DataSource = reader;
                gvCart.DataBind();
            }
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

    }
}