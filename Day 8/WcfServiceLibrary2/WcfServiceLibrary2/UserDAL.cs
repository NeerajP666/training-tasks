using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WcfServiceLibrary2
{
    public class UserDAL : BaseDAL
    {
        public bool Register(User user)
        {
            string query = "INSERT INTO Users(userid, username, password, emailid) " +
                           "VALUES(@userid, @userName, @Password, @Email)";

            SqlCommand cmd = new SqlCommand(query);
            cmd.Parameters.AddWithValue("@userid", user.UserId);
            cmd.Parameters.AddWithValue("@userName", user.Username);
            cmd.Parameters.AddWithValue("@Password", user.Password);
            cmd.Parameters.AddWithValue("@Email", user.Email);

            return ExecuteNonQuery(cmd) > 0;
        }

        public bool Login(string username, string password)
        {
            using (SqlConnection con = GetConnection())
            {
                string query = "SELECT COUNT(*) FROM Users WHERE Username=@Username AND Password=@Password";
                SqlCommand cmd = new SqlCommand(query, con);

                cmd.Parameters.AddWithValue("@userName", username);
                cmd.Parameters.AddWithValue("@Password", password);

                con.Open();
                int count = (int)cmd.ExecuteScalar();
                return count > 0;
            }
        }
    }
}
