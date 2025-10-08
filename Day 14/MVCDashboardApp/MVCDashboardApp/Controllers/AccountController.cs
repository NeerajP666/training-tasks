using MVCDashboardApp.Helpers;
using MVCDashboardApp.Models;
using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.Mvc;

namespace MVCDashboardApp.Controllers
{
    public class AccountController : Controller
    {
        private readonly string connectionString = ConfigurationManager.ConnectionStrings["mydbconnection"].ConnectionString;

        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(User user)
        {
            if (ModelState.IsValid)
            {
                string hashedPassword = EncryptionHelper.HashPassword(user.Password);

                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    string query = "INSERT INTO passwordencrypt (Username, Password) VALUES (@Username, @Password)";
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@Username", user.Username);
                        cmd.Parameters.AddWithValue("@Password", hashedPassword);

                        con.Open();
                        cmd.ExecuteNonQuery();
                    }
                }

                ViewBag.Message = "Registration successful!";
                return RedirectToAction("Login");
            }
            return View(user);
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string username, string password)
        {
            string hashedPassword = EncryptionHelper.HashPassword(password);

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "SELECT COUNT(1) FROM passwordencrypt WHERE Username=@Username AND Password=@Password";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@Username", username);
                    cmd.Parameters.AddWithValue("@Password", hashedPassword);

                    con.Open();
                    int count = Convert.ToInt32(cmd.ExecuteScalar());

                    if (count == 1)
                    {
                        Session["Username"] = username;
                        return RedirectToAction("Dashboard", "Home");
                    }
                    else
                    {
                        ViewBag.Message = "Invalid credentials!";
                        return View();
                    }
                }
            }
        }

        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Login");
        }
    }
}
