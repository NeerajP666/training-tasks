using AjaxEmployeeCRUD.Data;
using AjaxEmployeeCRUD.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace AjaxEmployeeCRUD.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly AppDbContext _context;

        public EmployeeController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var employees = _context.Employees
                .FromSqlRaw("exec sp_get_employees")
                .ToList();
            return Json(employees);
        }

        [HttpPost]
        public IActionResult Add([FromBody] Employee emp)
        {
            var parameters = new[]
            {
                new SqlParameter("@name", emp.Name),
                new SqlParameter("@position", emp.Position),
                new SqlParameter("@salary", emp.Salary)
            };

            _context.Database.ExecuteSqlRaw("exec sp_add_employee @name, @position, @salary", parameters);
            return Json(new { success = true, message = "Employee added successfully" });
        }

        [HttpPut]
        public IActionResult Update([FromBody] Employee emp)
        {
            var parameters = new[]
            {
                new SqlParameter("@id", emp.Id),
                new SqlParameter("@name", emp.Name),
                new SqlParameter("@position", emp.Position),
                new SqlParameter("@salary", emp.Salary)
            };

            _context.Database.ExecuteSqlRaw("exec sp_update_employee @id, @name, @position, @salary", parameters);
            return Json(new { success = true, message = "Employee updated successfully" });
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var param = new SqlParameter("@id", id);
            _context.Database.ExecuteSqlRaw("exec sp_delete_employee @id", param);
            return Json(new { success = true, message = "Employee deleted successfully" });
        }
    }
}
