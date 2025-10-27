using System.Diagnostics;
using AjaxAuthDemo.Models;
using Microsoft.AspNetCore.Mvc;

namespace AjaxAuthDemo.Controllers
{
    public class HomeController : Controller
    {

      

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Welcome()
        {
            // Optional: check if user logged in
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("Username")))
            {
                return RedirectToAction("Index");
            }

            ViewBag.Username = HttpContext.Session.GetString("Username");
            return View();
        }

    }
}
