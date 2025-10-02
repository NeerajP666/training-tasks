using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace UserServiceWCF
{
    public class UserDAL : DataAccessBase
    {
        public bool Register(string username, string password, string email)
        {
            string query = "INSERT INTO userwcf(username,password,emailid) VALUES(@u,@p,@e)";
            SqlParameter[] param =
            {
               
            new SqlParameter("@u", username),
            new SqlParameter("@p", password),
            new SqlParameter("@e", email)
        };

            return Execute(query, param, cmd => cmd.ExecuteNonQuery() > 0);
        }

        public bool Login(string username, string password)
        {
            string query = "SELECT COUNT(*) FROM userwcf WHERE username=@u AND password=@p";
            SqlParameter[] param =
            {
            new SqlParameter("@u", username),
            new SqlParameter("@p", password)
        };

            return Execute(query, param, cmd => (int)cmd.ExecuteScalar() > 0);
        }
        public int GetNextUserID()
        {
            string query = "SELECT ISNULL(MAX(userid), 0) + 1 FROM userwcf";
            SqlParameter[] param = { };

            return Execute(query, param, cmd => Convert.ToInt32(cmd.ExecuteScalar()));
        }

    }

}