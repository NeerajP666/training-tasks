using ExpenseTracker2.Data;
using ExpenseTracker2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace ExpenseTracker2.Controllers
{
    public class ExpenseController : Controller
    {
        private readonly AppDbContext _context;
        public ExpenseController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var expenses = _context.Expenses.Include(e => e.Category).ToList();
            return View(expenses);
        }

        public IActionResult Create()
        {
            ViewBag.Categories = new SelectList(_context.Categories, "Id", "Name");
            return View();
        }

        [HttpPost]
        public IActionResult Create(Expense expense)
        {
            //if (ModelState.IsValid)
            //{
                _context.Expenses.Add(expense);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            //}
            //ViewBag.Categories = new SelectList(_context.Categories, "Id", "Name", expense.CategoryId);
            //return View(expense);
        }

        public IActionResult Edit(int id)
        {
            var expense = _context.Expenses.Find(id);
            if (expense == null) return NotFound();
            ViewBag.Categories = new SelectList(_context.Categories, "Id", "Name", expense.CategoryId);
            return View(expense);
        }

        [HttpPost]
        public IActionResult Edit(Expense expense)
        {
            if (ModelState.IsValid)
            {
                _context.Expenses.Update(expense);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            ViewBag.Categories = new SelectList(_context.Categories, "Id", "Name", expense.CategoryId);
            return View(expense);
        }

        public IActionResult Delete(int id)
        {
            var expense = _context.Expenses.Find(id);
            if (expense != null)
            {
                _context.Expenses.Remove(expense);
                _context.SaveChanges();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
