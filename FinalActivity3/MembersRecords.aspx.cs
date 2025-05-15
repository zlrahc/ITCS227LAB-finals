using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataHelper;

namespace FinalActivity3
{
    public partial class MemberRecords : System.Web.UI.Page
    {
     
        private string connStr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|MAINDB.mdf;Integrated Security=True";
        
        protected void Page_Load(object sender, EventArgs e)
        {


            if (!IsPostBack)
            {
                LoadGridData();
            }

        }

        DataAccess db = new DataAccess();

        private void LoadGridData()
        {

            using (SqlConnection conn = new SqlConnection(connStr))
            {

                using (SqlCommand cmd = new SqlCommand("GetUserInfo", conn))
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

    }
}