using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace MVCProject.DAL
{
    public class UserRepository
    {
        public bool RegisterUser(string username, string password)
        {
            string connStr = ConfigurationManager.ConnectionStrings["mydbconnection"].ConnectionString;
            using (SqlConnection con = new SqlConnection(connStr))
            {
                SqlCommand cmd = new SqlCommand("INSERT INTO usermvc (Username, Password) VALUES (@u, @p)", con);
                cmd.Parameters.AddWithValue("@u", username);
                cmd.Parameters.AddWithValue("@p", password);
                con.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public bool ValidateUser(string username, string password)
        {
            string connStr = ConfigurationManager.ConnectionStrings["mydbconnection"].ConnectionString;

            using (SqlConnection con = new SqlConnection(connStr))
            {
                SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM usermvc WHERE Username=@u AND Password=@p", con);
                cmd.Parameters.AddWithValue("@u", username);
                cmd.Parameters.AddWithValue("@p", password);
                con.Open();
                int count = (int)cmd.ExecuteScalar();
                return count > 0;
            }
        }
    }

}
