using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataHelper;

namespace FinalActivity3
{
    public partial class AdminDashboard : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        DataAccess db = new DataAccess();
        protected void btnUpload_Click(object sender, EventArgs e)
        {

            string str = fldImage.FileName;
            fldImage.PostedFile.SaveAs(Server.MapPath("assets/" + str));
            string Image = "~/assets/" + str.ToString();

            Response.Write(Image);

            bool success = db.UploadImage(Image);
            if (success)
            {
                Response.Write("sumakses ka ");
            }
            else
            {
                Response.Write("Registration failed. Try again.");
            }


        }
    }
}