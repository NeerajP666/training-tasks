using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ClaySysTrainingApp
{
    public partial class login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }


        protected void Button2_Click(object sender, EventArgs e)
        {
            string username = TextBox1.Text;
            string password = TextBox2.Text;
            if (Session["regname"]!=null && Session["regpassword"]!=null)
            {
                if (username == Session["regname"].ToString() && password == Session["regpassword"].ToString())
                {
                    Session["a"] = username;
                    Response.Redirect("welcome.aspx");
                }
                else
                {
                    Label3.Text = " Invalid username or password";
                }

            }
            else
            {
                Label3.Text = "register first";
            }
        }
    }
}