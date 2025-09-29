using ClaysysTraining2.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ClaysysTraining2
{
    public partial class register1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string username = TextBox1.Text.Trim();
            string password = TextBox2.Text.Trim();
            string email = TextBox3.Text.Trim();

            using (SqlConnection con = DBHelper.GetConnection())
            {
                
                SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Users WHERE username=@userName", con);
                da.SelectCommand.Parameters.AddWithValue("@userName", username);

                DataTable dt = new DataTable();
                da.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    Label4.Text = "Username already exists.";
                }
                else
                {
                   
                    string query = "INSERT INTO Users (userid, username, password, emailid) VALUES (@UserId, @userName, @Password, @Email)";
                    SqlParameter[] parameter =
                    {
                new SqlParameter("@UserId", GetNextUserID()),   
                new SqlParameter("@userName", username),
                new SqlParameter("@Password", password),
                new SqlParameter("@Email", email)
            };

                    int result = DBHelper.ExecuteNonQuery(query, parameter);

                    Label4.Text = result > 0 ? "Registration successful" : "Registration failed";

                    if (result > 0)
                    {
                        Response.Redirect("login2.aspx");
                    }
                }
            }
        }
        

        private int GetNextUserID()
        {
            string query = "SELECT ISNULL(MAX(userid), 0) + 1 FROM Users";
            return Convert.ToInt32(DBHelper.ExecuteScalar(query, null));
        }

    }
    }
