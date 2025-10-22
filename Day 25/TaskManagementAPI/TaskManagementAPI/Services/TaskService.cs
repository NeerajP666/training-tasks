using Microsoft.EntityFrameworkCore;
using TaskManagementAPI.Data;
using TaskManagementAPI.DTOs;
using TaskManagementAPI.Models;

namespace TaskManagementAPI.Services
{
    public class TaskService : ITaskService
    {
        private readonly AppDbContext _context;

        public TaskService(AppDbContext context)
        {
            _context = context;
        }

       
        public IEnumerable<TaskDto> GetAll()
        {
            return _context.Tasks
                .Include(t => t.User)
                .Select(t => new TaskDto
                {
                    Id = t.Id,
                    Title = t.Title,
                    Description = t.Description,
                    IsCompleted = t.IsCompleted,
                    User = t.User != null
                        ? new UserDto
                        {
                            Id = t.User.Id,
                            Name = t.User.Name,
                            Email = t.User.Email
                        }
                        : null
                })
                .ToList();
        }

      
        public TaskDto GetById(int id)
        {
            var task = _context.Tasks
                .Include(t => t.User)
                .FirstOrDefault(t => t.Id == id);

            if (task == null) return null;

            return new TaskDto
            {
                Id = task.Id,
                Title = task.Title,
                Description = task.Description,
                IsCompleted = task.IsCompleted,
                User = task.User != null
                    ? new UserDto
                    {
                        Id = task.User.Id,
                        Name = task.User.Name,
                        Email = task.User.Email
                    }
                    : null
            };
        }

       
        public TaskDto Add(TaskItem task)
        {
            _context.Tasks.Add(task);
            _context.SaveChanges();

           
            var user = task.UserId.HasValue
                ? _context.Users.FirstOrDefault(u => u.Id == task.UserId.Value)
                : null;

            return new TaskDto
            {
                Id = task.Id,
                Title = task.Title,
                Description = task.Description,
                IsCompleted = task.IsCompleted,
                User = user != null
                    ? new UserDto
                    {
                        Id = user.Id,
                        Name = user.Name,
                        Email = user.Email
                    }
                    : null
            };
        }


        public TaskDto Update(TaskItem task)
        {
            _context.Tasks.Update(task);
            _context.SaveChanges();

            var user = task.UserId.HasValue
                ? _context.Users.FirstOrDefault(u => u.Id == task.UserId.Value)
                : null;

            return new TaskDto
            {
                Id = task.Id,
                Title = task.Title,
                Description = task.Description,
                IsCompleted = task.IsCompleted,
                User = user != null
                    ? new UserDto
                    {
                        Id = user.Id,
                        Name = user.Name,
                        Email = user.Email
                    }
                    : null
            };
        }

     
        public bool Delete(int id)
        {
            var task = _context.Tasks.Find(id);
            if (task == null) return false;

            _context.Tasks.Remove(task);
            _context.SaveChanges();
            return true;
        }
    }
}
