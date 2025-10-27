using Microsoft.EntityFrameworkCore;
using QuizMaster.Models;
using System.Collections.Generic;

namespace QuizMaster.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; } 
        public DbSet<Quiz> Quizzes { get; set; }
        public DbSet<Question> Questions { get; set; } 
        public DbSet<Attempt> Attempts { get; set; } 
        public DbSet<Answer> Answers { get; set; } 
    }
}
