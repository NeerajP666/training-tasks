using ClaysysTraining2.DAL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ClaysysTraining2
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            using (SqlConnection con = DBHelper.GetConnection())
            {
                con.Open();
                Response.Write("Database Connected Successfully!");
                con.Close();
            }
        }
    }
}