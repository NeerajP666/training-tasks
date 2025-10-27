using Microsoft.AspNetCore.Mvc;

namespace ExpenseTracker2.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
