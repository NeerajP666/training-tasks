using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCProject.BLL;

namespace MVCProject.Controllers
{
    public class HomeController : Controller
    {
        private readonly UserManager userManager = new UserManager();

        [HttpGet]
        public ActionResult Register() => View();

        [HttpPost]
        public ActionResult Register(string username, string password)
        {
            bool success = userManager.Register(username, password);
            ViewBag.Message = success ? "Registration successful!" : "Registration failed!";
            return View();
        }

        [HttpGet]
        public ActionResult Login() => View();

        [HttpPost]
        public ActionResult Login(string username, string password)
        {
            bool valid = userManager.Login(username, password);
            if (valid)
                return RedirectToAction("Dashboard");

            ViewBag.Message = "Invalid credentials!";
            return View();
        }

        public ActionResult Dashboard() => View();
    }
}