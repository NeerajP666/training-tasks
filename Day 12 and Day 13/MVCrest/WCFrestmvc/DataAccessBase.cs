using System;
using System.Configuration;
using System.Data.SqlClient;

namespace WCFrestmvc
{
    public abstract class DataAccessBase
    {
        protected string connectionString = ConfigurationManager.ConnectionStrings["mydbconnection"].ConnectionString;

        protected delegate T ExecuteCommand<T>(SqlCommand cmd);

        protected T Execute<T>(string query, SqlParameter[] parameters, ExecuteCommand<T> execMethod)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                if (parameters != null)
                    cmd.Parameters.AddRange(parameters);

                con.Open();
                return execMethod(cmd);
            }
        }
    }
}
