using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Configuration;
using System.ServiceModel.Security;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using WebAppForREST.ServiceReference1;

namespace WebAppForREST
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            ServiceReference1.Service1Client client = new ServiceReference1.Service1Client();
            UserCredentials user = new UserCredentials()
            {
               UserName=TextBox1.Text,
               Password=TextBox2.Text
             };

            bool isValid = client.Login(user);

            if (isValid)
                Label3.Text = "Login Successful!";
            else
                Label3.Text = "Invalid username or password.";
        }
    }
}