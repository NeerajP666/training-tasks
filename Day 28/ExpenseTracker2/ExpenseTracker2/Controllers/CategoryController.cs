using ExpenseTracker2.Data;
using ExpenseTracker2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ExpenseTracker2.Controllers
{
    public class CategoryController : Controller
    {
        private readonly AppDbContext _context;
        public CategoryController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var categories = _context.Categories.ToList();
            return View(categories);
        }

        public IActionResult Create()
        {
            return View();
        }

        //[HttpPost]
        //public IActionResult Create(Category category)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _context.Categories.Add(category);
        //        _context.SaveChanges();
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(category);
        //}


        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public IActionResult Create(Category category)
        //{
        //    Console.WriteLine("POST hit!"); // Debug
        //    Console.WriteLine($"Category Name: {category.Name}");

        //    if (!ModelState.IsValid)
        //    {
        //        var errors = ModelState.Values.SelectMany(v => v.Errors);
        //        foreach (var e in errors)
        //            Console.WriteLine(e.ErrorMessage);
        //        return View(category);
        //    }

        //    _context.Categories.Add(category);
        //    _context.SaveChanges();
        //    return RedirectToAction(nameof(Index));
        //}


        [HttpPost]
        //[ValidateAntiForgeryToken]
        public IActionResult Create(Category category)
        {
            //if (ModelState.IsValid)
            //{
                _context.Categories.Add(category);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            //    }
            //    return View(category);
        }

        public IActionResult Edit(int id)
        {
            var category = _context.Categories.Find(id);
            if (category == null) return NotFound();
            return View(category);
        }

        [HttpPost]
        public IActionResult Edit(Category category)
        {
            if (ModelState.IsValid)
            {
                _context.Categories.Update(category);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(category);
        }

        public IActionResult Delete(int id)
        {
            var category = _context.Categories.Find(id);
            if (category != null)
            {
                _context.Categories.Remove(category);
                _context.SaveChanges();
            }
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public IActionResult TestSave()
        {
            _context.Categories.Add(new Category { Name = "TestCategory" });
            _context.SaveChanges();
            return Content("Saved!");
        }

    }
}
