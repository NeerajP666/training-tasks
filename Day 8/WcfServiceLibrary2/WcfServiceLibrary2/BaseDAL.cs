using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WcfServiceLibrary2
{
    public abstract class BaseDAL
    {
        protected SqlConnection GetConnection()
        {
            return DataAccess.GetConnection();
        }

        protected delegate int ExecuteNonQueryDelegate(SqlCommand cmd);

        protected int ExecuteNonQuery(SqlCommand cmd)
        {
            using (SqlConnection con = GetConnection())
            {
                cmd.Connection = con;
                con.Open();
                return cmd.ExecuteNonQuery();
            }
        }
        public static object ExecuteScalar(string query, SqlParameter[] parameters)
        {
            using (SqlConnection con = DataAccess.GetConnection())
            {
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    if (parameters != null)
                    {
                        cmd.Parameters.AddRange(parameters);
                    }
                    con.Open();
                    return cmd.ExecuteScalar();
                }
            }
        }
    }
}
