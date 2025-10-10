using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.Mvc;
using Learn1.Models;

namespace Learn1.Controllers
{
    public class AccountController : Controller
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["Learn1Connection"].ConnectionString;

        // GET: Register
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(User user)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO Learn1 (Name, Password, Email) VALUES (@Name, @Password, @Email)";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Name", user.Name);
                cmd.Parameters.AddWithValue("@Password", user.Password);
                cmd.Parameters.AddWithValue("@Email", user.Email);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }

            ViewBag.Message = "Registration Successful!";
            return RedirectToAction("Login", "Account");
        }

        // GET: Login
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(User user)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "SELECT COUNT(*) FROM Learn1 WHERE Username=@Username AND Password=@Password";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Username", user.Name);
                cmd.Parameters.AddWithValue("@Password", user.Password);
                con.Open();
                int count = (int)cmd.ExecuteScalar();
                con.Close();

                if (count == 1)
                {
                    Session["Username"] = user.Name;
                    return RedirectToAction("Dashboard");
                }
                else
                {
                    ViewBag.Message = "Invalid Username or Password";
                    return View();
                }
            }
        }

        public ActionResult Dashboard()
        {
            if (Session["Username"] == null)
                return RedirectToAction("Login");

            ViewBag.Username = Session["Username"].ToString();
            return View();
        }

        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Login");
        }
    }
}
