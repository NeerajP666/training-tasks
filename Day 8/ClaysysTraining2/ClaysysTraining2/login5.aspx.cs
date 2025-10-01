using ClaysysTraining2.DAL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection.Emit;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ClaysysTraining2
{
    public partial class login5 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
       
        protected void Button1_Click(object sender, EventArgs e)
        {
            ServiceReference8.User user = new ServiceReference8.User
            {
                username = TextBox1.Text.Trim(),
                password = TextBox2.Text.Trim()
            };

            // Create the WCF service client
            ServiceReference8.Service1Client client = new ServiceReference8.Service1Client();
            

            // Call the LoginUser method in WCF
            bool isValid = client.Login(user);

            if (isValid)
            {
                Response.Redirect("Welcome.aspx");
            }
            else
            {
                Label3.Text = "Invalid username or password.";
            }

            // Close the client
            client.Close();
        }
    }
}