using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataHelper
{

    public class ClientUser
    {
        public string UserID { get; set; }
        public string UserName { get; set; }
        public string MemberType { get; set; }
    }

    public class DataAccess
    {

        private string connStr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|MainDatabase.mdf;Integrated Security=True";

        public bool RegisterUser(string UserName, string Email, string Password, string MemberType)
        {

            using (SqlConnection conn = new SqlConnection(connStr))
            {

                try
                {

                    conn.Open();

                    string UserID = DateTime.Now.ToString("MMddyy-HHmm");

                    SqlCommand cmd = new SqlCommand("RegisterUser", conn);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@UserID", UserID);
                    cmd.Parameters.AddWithValue("@UserName", UserName);
                    cmd.Parameters.AddWithValue("@Email", Email);
                    cmd.Parameters.AddWithValue("@Password", Password);
                    cmd.Parameters.AddWithValue("@MemberType", MemberType);

                    cmd.ExecuteNonQuery();

                    return true;

                }
                catch
                {
                    return false;
                }

            }

        }

        public ClientUser LoginUser(string email, string password)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("LoginUser", conn);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Email", email);
                    cmd.Parameters.AddWithValue("@Password", password);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new ClientUser
                            {
                                UserID = reader["UserID"].ToString(),
                                UserName = reader["UserName"].ToString(),
                                MemberType = reader["MemberType"].ToString()
                            };
                        }
                        else
                        {
                            return null;
                        }
                    }
                }
                catch
                {
                    return null;
                }
            }
        }

    }
}
