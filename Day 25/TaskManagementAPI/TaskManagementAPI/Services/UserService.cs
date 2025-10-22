using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;
using TaskManagementAPI.Data;
using TaskManagementAPI.DTOs;
using TaskManagementAPI.Models;

namespace TaskManagementAPI.Services
{
    public class UserService : IUserService
    {
        private readonly AppDbContext _context;

        public UserService(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<UserDto> GetAll()
        {
            return _context.Users
                .Include(u => u.Tasks)
                .Select(u => new UserDto
                {
                    Id = u.Id,
                    Name = u.Name,
                    Email = u.Email
                })
                .ToList();
        }

        public UserDto GetById(int id)
        {
            var user = _context.Users
                .Include(u => u.Tasks)
                .FirstOrDefault(u => u.Id == id);

            if (user == null) return null;

            return new UserDto
            {
                Id = user.Id,
                Name = user.Name,
                Email = user.Email
            };
        }

        public UserDto Add(User user)
        {
        
            var emailPattern = @"^[\w\.-]+@[\w\.-]+\.\w+$";
            if (!Regex.IsMatch(user.Email, emailPattern))
                throw new Exception("Invalid email format.");

            _context.Users.Add(user);
            _context.SaveChanges();

            return new UserDto
            {
                Id = user.Id,
                Name = user.Name,
                Email = user.Email
            };
        }

        public UserDto Update(User user)
        {
 
            var emailPattern = @"^[\w\.-]+@[\w\.-]+\.\w+$";
            if (!Regex.IsMatch(user.Email, emailPattern))
                throw new Exception("Invalid email format.");

            _context.Users.Update(user);
            _context.SaveChanges();

            return new UserDto
            {
                Id = user.Id,
                Name = user.Name,
                Email = user.Email
            };
        }

        public bool Delete(int id)
        {
            var user = _context.Users.Find(id);
            if (user == null) return false;
            _context.Users.Remove(user);
            _context.SaveChanges();
            return true;
        }
    }
}
