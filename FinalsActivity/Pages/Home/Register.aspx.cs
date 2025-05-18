using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataHelper;

namespace FinalsActivity.Pages.Home
{
    public partial class Register : System.Web.UI.Page
    {

        DataAccess dataAccess = new DataAccess();

        protected void Page_Load(object sender, EventArgs e)
        {



        }



        protected void btnRegister_Click(object sender, EventArgs e)
        {

            string UserName = txtFirstName.Text + " " + txtLastName.Text;

            bool success = dataAccess.RegisterUser(UserName, txtEmailAddress.Text.Trim(), txtPassword.Text.Trim(), drpMemberType.SelectedItem.Text);

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