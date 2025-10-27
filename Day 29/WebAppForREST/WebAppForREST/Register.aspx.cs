using System;
using System.ServiceModel;
using System.Web.UI;
using WebAppForREST.ServiceReference1;

namespace WebAppForREST
{
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                ServiceReference1.Service1Client client = new ServiceReference1.Service1Client();

                UserCredentials user = new UserCredentials()
                {
                    UserName = TextBox1.Text,
                    Password = TextBox2.Text,
                    Email = TextBox3.Text
                };

                bool isValid = client.Register(user);

                if (isValid)
                    Label3.Text = "Registration Successful!";
                else
                    Label3.Text = "Invalid username or password.";
            }
           
            catch (Exception ex)
            {
              
                Label3.Text = "Unexpected error: " + ex.Message;
            }
        }
    }
}
