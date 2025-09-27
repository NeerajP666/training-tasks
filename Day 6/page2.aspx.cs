using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ClaySysTrainingApp
{
    public partial class page2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserName"]!=null)
            {
                Label1.Text = "welcome " + Session["UserName"].ToString() + "!!!!!!!!!!!!!!!!!";
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            if(RadioButton1.Checked)
            {
                Label2.Text = "you selected male";
            }
            else if(RadioButton2.Checked)
            {
                Label2.Text="you selected female";
            }
            else
            {
                Label2.Text = "please select gender";
            }
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            string em = TextBox1.Text;
            Label3.Text = "your email is " + em;
        }
    }
}