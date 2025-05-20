using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataHelper;

namespace FinalsActivity.Pages.Home
{
    public partial class Login : System.Web.UI.Page
    {

        DataAccess dataAccess = new DataAccess();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {

            ClientUser loggedInUser = dataAccess.LoginUser(txtEmailAddress.Text.Trim(), txtPassword.Text.Trim());

            if (loggedInUser != null)
            {
                
                Session["UserID"] = loggedInUser.UserID;
                Session["UserName"] = loggedInUser.UserName;
                Session["MemberType"] = loggedInUser.MemberType;

                Response.Redirect("~/Pages/User/Storefront.aspx");
            }
            else
            {
                Response.Write("Login failed. Try again.");
            }

        }
    }
}