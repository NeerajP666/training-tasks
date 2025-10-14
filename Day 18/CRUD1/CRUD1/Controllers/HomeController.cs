using CRUD1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CRUD1.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(User model)
        {
            if (ModelState.IsValid)
            {
                using (var db = new databaseconnectivity())
                {
                    db.users.Add(model);
                    db.SaveChanges();
                }
                ViewBag.Message = "Registration successful!";
                return RedirectToAction("Login");
            }
            var errors = ModelState.Values.SelectMany(v => v.Errors);
            foreach (var error in errors)
            {
                System.Diagnostics.Debug.WriteLine(error.ErrorMessage);
            }

            return View(model);
        }


        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(User model)
        {
            using (var db = new databaseconnectivity())
            {
                var user = db.users.FirstOrDefault(u => u.Email == model.Email && u.Password == model.Password);
                if (user != null)
                {
                    Session["UserId"] = user.Id;
                    Session["UserName"] = user.Name;
                    return RedirectToAction("Dashboard");
                }
                else
                {
                    ViewBag.Error = "Invalid email or password";
                }
            }
            return View(model);
        }


        public ActionResult Dashboard()
        {
            if (Session["UserId"] == null)
                return RedirectToAction("Login");

            int userId = Convert.ToInt32(Session["UserId"]);
            using (var db = new databaseconnectivity())
            {
                var user = db.users.Find(userId);
                return View(user);
            }
        }



        [HttpGet]
        public ActionResult Edit(int id)
        {
            using (var db = new databaseconnectivity())
            {
                var user = db.users.Find(id);
                return View(user);
            }
        }

        [HttpPost]
        public ActionResult Edit(User model)
        {
            using (var db = new databaseconnectivity())
            {
                var existingUser = db.users.Find(model.Id);
                if (existingUser != null)
                {
                    existingUser.Name = model.Name;
                    existingUser.Email = model.Email;
                    existingUser.Age = model.Age;
                    existingUser.City = model.City;
                    existingUser.Gender = model.Gender;
                    existingUser.IsAgree = model.IsAgree;
                    existingUser.Profession = model.Profession;
                    existingUser.AboutMe = model.AboutMe;
                    db.SaveChanges();
                }
                return RedirectToAction("Dashboard");
            }
        }


        public ActionResult Delete(int id)
        {
            using (var db = new databaseconnectivity())
            {
                var user = db.users.Find(id);
                if (user != null)
                {
                    db.users.Remove(user);
                    db.SaveChanges();
                }
            }
            return RedirectToAction("Login"); 
        }


        [HttpGet]
        public ActionResult UsersList()
        {
            using (var db = new databaseconnectivity())
            {
                var users = db.users.ToList(); // get all users
                return View(users);
            }
        }

        public ActionResult DeleteUser(int id)
        {
            using (var db = new databaseconnectivity())
            {
                var user = db.users.Find(id);
                if (user != null)
                {
                    db.users.Remove(user);
                    db.SaveChanges();
                }
            }
            return RedirectToAction("UsersList");
        }




    }
}