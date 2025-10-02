using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;    
using System.Configuration;

namespace Graph
{
    public partial class chart : System.Web.UI.Page
    {
        public string Labels = "";
        public string DataPoints = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            var labelList = new List<string>();
            var dataList = new List<int>();

            string connString = ConfigurationManager.ConnectionStrings["mydbconnection"].ConnectionString;

            using (var con = new SqlConnection(connString))
            {
                string query = @"
                SELECT registerDate, COUNT(*) AS Count
                FROM UserRegistration
                GROUP BY registerDate
                ORDER BY registerDate";

                using (var cmd = new SqlCommand(query, con))
                {
                    con.Open();
                    var reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        labelList.Add("'" + Convert.ToDateTime(reader["registerDate"]).ToString("yyyy-MM-dd") + "'");
                        dataList.Add(Convert.ToInt32(reader["Count"]));
                    }
                }
            }
            Labels = string.Join(",", labelList);
            DataPoints = string.Join(",", dataList);

        }
      
    }
}