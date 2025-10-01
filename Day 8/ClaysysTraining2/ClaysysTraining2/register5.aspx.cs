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
    public partial class register5 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string username = TextBox1.Text.Trim();
            string password = TextBox2.Text.Trim();
            string email = TextBox3.Text.Trim();

            try
            {
                // Create the WCF service client
                ServiceReference8.Service1Client client = new ServiceReference8.Service1Client();

                // Create a User object
                ServiceReference8.User newUser = new ServiceReference8.User
                {
                    userid = client.GetNextUserID(),
                    username = username,
                    password = password,
                    email = email
                };

                // Call RegisterUser method
                bool result = client.Register(newUser);

                // Show result
                Label4.Text = result ? "Registration successful!" : "Registration failed.";

                client.Close();

                // Redirect if successful
                if (result)
                {
                    Response.Redirect("login5.aspx");
                }
            }
            catch (Exception ex)
            {
                Label4.Text = "Error: " + ex.Message;
            }
        }
    }
}