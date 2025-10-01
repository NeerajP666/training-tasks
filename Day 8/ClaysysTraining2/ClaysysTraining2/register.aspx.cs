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
    public partial class register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string username = TextBox1.Text.Trim();
            string password = TextBox2.Text.Trim(); 
            string email=TextBox3.Text.Trim();

            string query = "insert into users(userid,username,password,emailid) values(@UserID,@userName,@Password,@Email)";

            SqlParameter[] parameter =
            {
                new SqlParameter("@UserId", GetNextUserID()),
                new SqlParameter("@userName",username),
                new SqlParameter("@Password",password),
                new SqlParameter("@Email",email)
            };
            int result=DBHelper.ExecuteNonQuery(query, parameter);
            Label4.Text = result>0 ? "success" : "unsuccessfull";
            if(result > 0)
            {
                Response.Redirect("login2.aspx");
            }
        }
        private int GetNextUserID()
        {
            string query = "select isnull(max(userid), 0) + 1 from users";
            return Convert.ToInt32(DBHelper.ExecuteScalar(query,null));
        }
    }
}