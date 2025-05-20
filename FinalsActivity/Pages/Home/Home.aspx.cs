using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FinalsActivity.Pages.Home
{
    public partial class Home : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["MemberType"] != null)
            {
                string account = Session["MemberType"].ToString().ToLower();

                if (account == "admin")
                {
                    Response.Redirect("~/Pages/Admin/AdminDashboard.aspx");
                }
                else
                {
                    Response.Redirect("~/Pages/User/Storefront.aspx");
                }
            }

        }
    }
}