using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCDashboardApp.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Dashboard()
        {
            if (Session["Username"] == null)
                return RedirectToAction("Login", "Account");

            ViewBag.Username = Session["Username"].ToString();
            return View();
        }
    }
}