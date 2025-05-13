using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    internal class DataAccess
    {

        private string connStr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Shantel\source\repos\ITCS227LAB-finals\FinalActivity3\App_Data\MAINDB.mdf;Integrated Security=True";
        
        public bool RegisterUser(string UserName, string Email, string Password, string Membership) {

            using (SqlConnection conn = new SqlConnection(connStr))
            {

                try
                {

                    conn.Open();
                    SqlCommand cmd = new SqlCommand("RegisterUser", conn);

                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@UserName", UserName);
                    cmd.Parameters.AddWithValue("@Email", Email);
                    cmd.Parameters.AddWithValue("@Password", Password);
                    cmd.Parameters.AddWithValue("@Membership", Membership);

                    return true;

                }
                catch
                {
                    return false;
                }

            }

        }

    }
}
