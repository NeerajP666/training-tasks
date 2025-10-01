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
    public partial class login1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string username = TextBox1.Text.Trim();
            string password = TextBox2.Text.Trim();
            using (SqlConnection con = DBHelper.GetConnection())
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("storeduser", con))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@userName", username);
                    cmd.Parameters.AddWithValue("@Password", password);

                    int count = Convert.ToInt32(cmd.ExecuteScalar());
                    if (count > 0)
                    {
                        Session["username"] = username;
                        Response.Redirect("Welcome.aspx");
                    }
                    else
                    {
                        Label3.Text = "Invalid username or password.";
                    }
                }
            }
        }
    }
}