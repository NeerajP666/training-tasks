using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ClaysysTraining2.DAL
{
    public class DBHelper
    {
        private static string conStr = ConfigurationManager.ConnectionStrings["mydbconnection"].ConnectionString;
        public static SqlConnection GetConnection()
        {
            return new SqlConnection(conStr);
        }
        public static int ExecuteNonQuery(string query, SqlParameter[] parameters)
        {
            int result = 0;
            using(SqlConnection con = GetConnection())
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand(query,con))
                {
                    if(parameters!= null)
                    {
                        cmd.Parameters.AddRange(parameters);
                    }
                    result=cmd.ExecuteNonQuery();
                }
            }
            return result;
        }
        public static object ExecuteScalar(string query, SqlParameter[] parameters)
        {
            object result;
            using (SqlConnection con = GetConnection())
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    if (parameters != null)
                    {
                        cmd.Parameters.AddRange(parameters);
                    }
                    result = cmd.ExecuteScalar();
                }
            }
            return result;
        }
       
    }
}