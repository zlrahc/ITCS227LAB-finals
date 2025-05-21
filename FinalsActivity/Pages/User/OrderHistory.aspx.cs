using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Util;

namespace FinalsActivity.Pages.User
{
    public partial class OrderHistory : System.Web.UI.Page
    {
        private string connStr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|MainDatabase.mdf;Integrated Security=True";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadTransactions(Session["UserID"].ToString());
            }
        }

        private void LoadTransactions(string userId)
        {
            DataTable dt = new DataTable();

            using (SqlConnection conn = new SqlConnection(connStr))
            using (SqlCommand cmd = new SqlCommand("GetOrderHistoryByUserID", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@UserID", userId);

                conn.Open();

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }

            gvTransactions.DataSource = dt;
            gvTransactions.DataBind();

            pnlDetails.Visible = false; // Hide details panel on reload
        }

        protected void gvTransactions_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "ViewDetails")
            {

                int index = Convert.ToInt32(e.CommandArgument);
                string transactionId = gvTransactions.DataKeys[index].Value.ToString();

                LoadTransactionDetails(transactionId);
            }
        }
        private void LoadTransactionDetails(string transactionId)
        {
            DataTable dt = new DataTable();

            using (SqlConnection conn = new SqlConnection(connStr))
            using (SqlCommand cmd = new SqlCommand("GetTransactionDetailsByTransactionID", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@TransactionID", transactionId);

                conn.Open();

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }

            gvDetails.DataSource = dt;
            gvDetails.DataBind();

            pnlDetails.Visible = true;
        }

    }
}