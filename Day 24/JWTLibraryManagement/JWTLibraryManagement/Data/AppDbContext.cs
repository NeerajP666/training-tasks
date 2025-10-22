using JWTLibraryManagement.Models;
using Microsoft.EntityFrameworkCore;

namespace JWTLibraryManagement.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Book> Book { get; set; }
        public DbSet<Author> Author { get; set; }
        public DbSet<Member> Member { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure relationships (optional here since conventions cover them, but explicit is clearer)
            modelBuilder.Entity<Book>()
                .HasOne(b => b.Author)
                .WithMany(a => a.Books)
                .HasForeignKey(b => b.AuthorId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Book>()
                .HasOne(b => b.Member)
                .WithMany(m => m.Books)
                .HasForeignKey(b => b.MemberId)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
