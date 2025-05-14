using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataHelper
{
    public class DataAccess
    {

        private string connStr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\chloe\Source\Repos\ITCS227LAB-finals\FinalActivity3\App_Data\MAINDB.mdf;Integrated Security=True";
        
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

                    cmd.ExecuteNonQuery();

                    return true;

                }
                catch
                {
                    return false;
                }

            }

        }

        public bool AddProduct(int Id, string ProductID, string ProductName, decimal Price, int Stocks, decimal SRP)
        {

            using (SqlConnection conn = new SqlConnection(connStr))
            {

                try
                {

                    conn.Open();
                    SqlCommand cmd = new SqlCommand("AddProduct", conn);

                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id", Id);
                    cmd.Parameters.AddWithValue("@ProductID", ProductID);
                    cmd.Parameters.AddWithValue("@ProductName", ProductName);
                    cmd.Parameters.AddWithValue("@Price", Price);
                    cmd.Parameters.AddWithValue("@Stock", Stocks);
                    cmd.Parameters.AddWithValue("@SRP", SRP);


                    cmd.ExecuteNonQuery();

                    return true;

                }
                catch
                {
                    return false;
                }

            }

            return false;

        }

    }
}
