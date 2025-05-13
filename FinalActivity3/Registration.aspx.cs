using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataHelper;


namespace FinalActivity3
{
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        DataAccess db = new DataAccess();

        protected void btnRegister_Click(object sender, EventArgs e)
        {

            string UserName = txtFirstName.Text + " " + txtLastName.Text;

            bool success = db.RegisterUser(UserName, txtEmailAddress.Text, txtPassword.Text, drpMembership.Text);
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