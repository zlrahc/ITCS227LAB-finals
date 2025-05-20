using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FinalsActivity.Pages.Admin
{
    public partial class AdminMaster : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["MemberType"] == null || Session["MemberType"].ToString() != "Admin")
            {

                Session.Clear();
                Session.Abandon();

                Response.Redirect("~/Pages/Home/Login.aspx");

            }

        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {

            Session.Clear();
            Session.Abandon();

            Response.Redirect("~/Pages/Home/Home.aspx");

        }
    }
}