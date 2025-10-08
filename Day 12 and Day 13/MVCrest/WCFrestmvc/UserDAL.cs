using System;
using System.Data.SqlClient;

namespace WCFrestmvc
{
    public class UserDAL : DataAccessBase
    {
        public bool Register(string username, string password, string email)
        {
            string query = "insert into userwcf(username,password,emailid) values(@u,@p,@e)";
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
            string query = "select count(*) from userwcf WHERE username=@u AND password=@p";
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
