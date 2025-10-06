using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ASPWCFWEB2
{
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string username = TextBox1.Text.Trim();
            string password = TextBox2.Text.Trim();
            string email = TextBox3.Text.Trim();
        

                ServiceReference2.Service1Client client = new ServiceReference2.Service1Client();
                ServiceReference2.User newUser = new ServiceReference2.User
                {
                    userid = client.GetNextUserID(),
                    username = username,
                    password = password,
                    email = email
                };
                bool result = client.Register(newUser);
                Label4.Text = result ? "Registration successful!" : "Registration failed.";

                client.Close();
                if (result)
                {
                    Response.Redirect("login.aspx");
                }
            }
            
        
    }
}