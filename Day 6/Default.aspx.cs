using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace ClaySysTrainingApp
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(IsPostBack)
            {
                Label2.Text = "this is the first time loading the page";
            }
            else
            {
                Label2.Text = "This is the second time loading the page";
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Label1.Text = "Hello, " + TextBox1.Text + "!";
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Session["UserName"] = TextBox1.Text;
            Response.Redirect("page2.aspx");
        }
    }
}