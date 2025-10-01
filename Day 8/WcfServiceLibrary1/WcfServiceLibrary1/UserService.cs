using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WcfServiceLibrary1
{
    public class UserService : IUserService
    {
        public bool RegisterUser(User user)
        {
            using (SqlConnection con = DataAccess.GetConnection())
            {
                string query = "INSERT INTO users(userid, username, password, emailid) " +
                               "VALUES(@userid, @userName, @Password, @Email)";
                SqlCommand cmd = new SqlCommand(query, con);

                cmd.Parameters.AddWithValue("@userid", user.UserId);
                cmd.Parameters.AddWithValue("@userName", user.Username);
                cmd.Parameters.AddWithValue("@Password", user.Password);
                cmd.Parameters.AddWithValue("@Email", user.Email); // mapping Email → Emailid

                con.Open();
                int rows = cmd.ExecuteNonQuery();
                return rows > 0;
            }
        }

        public bool LoginUser(string username, string password)
        {
            using (SqlConnection con = DataAccess.GetConnection())
            {
                string query = "SELECT COUNT(*) FROM users WHERE username=@userName AND password=@Password";
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
