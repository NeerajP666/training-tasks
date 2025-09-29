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
    public partial class login2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = DBHelper.GetConnection())
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("select * from users WHERE username=@userName AND password=@password", con);
                cmd.Parameters.AddWithValue("@userName", TextBox1.Text.Trim());
                cmd.Parameters.AddWithValue("@Password", TextBox2.Text.Trim());

                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows) 
                {
                    Session["username"] = TextBox1.Text;
                    Response.Redirect("Welcome.aspx");
                }
                else
                {
                    Label3.Text = "Invalid username or password.";
                }
                reader.Close();
            }
        }
    }
}