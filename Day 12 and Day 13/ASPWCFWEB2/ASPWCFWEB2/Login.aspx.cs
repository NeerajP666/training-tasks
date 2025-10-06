using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ASPWCFWEB2
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            ServiceReference1.User user = new ServiceReference1.User
            {
                username = TextBox1.Text.Trim(),
                password = TextBox2.Text.Trim()
            };


            ServiceReference1.Service1Client client = new ServiceReference1.Service1Client();

            bool isValid = client.Login(user);

            if (isValid)
            {
                Response.Redirect("Welcome.aspx");
            }
            else
            {
                Label3.Text = "Invalid username or password.";
            }

            client.Close();
        }
    }
}