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
    public partial class login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string username = TextBox1.Text.Trim();
            string password = TextBox2.Text.Trim();

            string query = "select count(*) from users where username=@userName and password=@Password";

            SqlParameter[] parameters = {
                            new SqlParameter("@userName", username),
                            new SqlParameter("@Password", password)
                                 };

            int count = Convert.ToInt32(DBHelper.ExecuteScalar(query, parameters));

            if (count > 0)
                Response.Redirect("Welcome.aspx"); 
            else
                Label3.Text = "Invalid username or password.";
        }
    }
}