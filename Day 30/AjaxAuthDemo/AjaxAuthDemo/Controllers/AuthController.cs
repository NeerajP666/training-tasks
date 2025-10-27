using AjaxAuthDemo.Data;
using AjaxAuthDemo.Models;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography;
using System.Text;

namespace AjaxAuthDemo.Controllers
{
    public class AuthController : Controller
    {

        private readonly AppDbContext _context;
        public AuthController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Register([FromBody] User user)
        {
            if(_context.users.Any(u=>u.username==user.username))
                return Json(new { success = false, message = "Username already exists" });
             user.password = HashPassword(user.password);
            _context.users.Add(user);
            _context.SaveChanges();

            return Json(new { success = true, message = "Registered successfully" });
        }
        [HttpPost]
        public IActionResult Login([FromBody] User user)
        {
            var existingUser = _context.users.FirstOrDefault(u => u.username == user.username);
            if (existingUser == null || !VerifyPassword(user.password, existingUser.password))
                return Json(new { success = false, message = "Invalid credentials" });

            HttpContext.Session.SetString("Username", user.username);
            return Json(new { success = true, message = "Login successful" });
        }

        private string HashPassword(string password)
        {
            using var sha=SHA256.Create();
            var bytes = sha.ComputeHash(Encoding.UTF8.GetBytes(password));
            return Convert.ToBase64String(bytes);
        }
        private bool VerifyPassword(string password, string hash) =>
           HashPassword(password) == hash;
    }
}
