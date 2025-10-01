using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;


namespace WcfServiceLibrary1
{
    public class DataAccess
    {
        private static string conStr = ConfigurationManager.ConnectionStrings["mydbconnection"].ConnectionString;

        public static SqlConnection GetConnection()
        {
            return new SqlConnection(conStr);
        }
    }
}
