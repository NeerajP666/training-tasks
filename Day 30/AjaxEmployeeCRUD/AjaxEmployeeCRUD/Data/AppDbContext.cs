using AjaxEmployeeCRUD.Models;
using Microsoft.EntityFrameworkCore;

namespace AjaxEmployeeCRUD.Data
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<Employee> Employees { get; set; }
    }
}
