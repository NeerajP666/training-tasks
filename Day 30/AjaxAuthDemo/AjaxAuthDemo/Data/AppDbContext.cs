using AjaxAuthDemo.Models;
using Microsoft.EntityFrameworkCore;

namespace AjaxAuthDemo.Data
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<User> users { get; set; }
        
    }
}
