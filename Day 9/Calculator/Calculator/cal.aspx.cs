using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Calculator
{
    public partial class cal : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnCalculate_Click(object sender, EventArgs e)
        {
            try
            {
                double num1 = double.Parse(txtNum1.Text.Trim());
                double num2 = double.Parse(txtNum2.Text.Trim());
                double result = 0;

                switch (ddlOperation.SelectedValue)
                {
                    case "Add":
                        result = num1 + num2;
                        break;
                    case "Subtract":
                        result = num1 - num2;
                        break;
                    case "Multiply":
                        result = num1 * num2;
                        break;
                    case "Divide":
                        result = num1 / num2; 
                        break;
                }

                lblResult.Text = "Result: " + result.ToString();
            }
            catch (Exception ex)
            {
                lblLog.Text = "Error: " + ex.Message;

                try
                {
                    string connString = ConfigurationManager.ConnectionStrings["mydbconnection"].ConnectionString;

                    using (SqlConnection con = new SqlConnection(connString))
                    {
                        string query = "INSERT INTO error (message, trace, logdate) VALUES (@msg, @trace, @date)";
                        SqlCommand cmd = new SqlCommand(query, con);

                        cmd.Parameters.AddWithValue("@msg", ex.Message);
                        cmd.Parameters.AddWithValue("@trace", ex.StackTrace ?? "No stack trace");
                        cmd.Parameters.AddWithValue("@date", DateTime.Now);

                        con.Open();
                        cmd.ExecuteNonQuery();
                    }
                }
                catch (Exception logEx)
                {
                    lblLog.Text += " | Logging failed: " + logEx.Message;
                }
                try
                {
                    string logPath = Server.MapPath("~/Logs/ErrorLog.txt");
                    using (StreamWriter sw = new StreamWriter(logPath, true))
                    {
                        sw.WriteLine("Error Log");
                        sw.WriteLine("Date: " + DateTime.Now.ToString());
                        sw.WriteLine("Message: " + ex.Message);
                        sw.WriteLine("Stack Trace: " + ex.StackTrace);
                        sw.WriteLine("____________");
                    }
                }
                catch (Exception fileEx)
                {
                    lblLog.Text += " | File Logging failed: " + fileEx.Message;
                }

                
            }
            finally
            {
                lblLog.Text += " | Finally block executed.";
            }

        }
    }
}