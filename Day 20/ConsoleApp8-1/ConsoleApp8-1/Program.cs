using System;
using System.Collections.Generic;

namespace ConsoleApp8_1
{
    
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public User(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public void DisplayInfo()
        {
            Console.WriteLine($"ID: {Id}, Name: {Name}");
        }
    }

    public class AdminUser : User
    {
        public string Role { get; set; }

        public AdminUser(int id, string name, string role)
            : base(id, name)
        {
            Role = role;
        }

       
        public void DisplayAdminInfo()
        {
            DisplayInfo();
            Console.WriteLine($"Role: {Role}");
        }
    }

    public interface IUserService
    {
        void AddUser();
        void ViewUsers();
        void DeleteUser();
    }

    public class UserService : IUserService
    {
        private readonly List<User> _users = new();

        public void AddUser()
        {
            Console.Write("Enter ID: ");
            int id = int.Parse(Console.ReadLine()!);

            if (_users.Exists(u => u.Id == id))
            {
                Console.WriteLine("User with this ID already exists.\n");
                return;
            }

            Console.Write("Enter Name: ");
            string name = Console.ReadLine()!;

            Console.Write("Is this user an Admin? (y/n): ");
            string ans = Console.ReadLine()!.ToLower();

            User user;
            if (ans == "y")
            {
                Console.Write("Enter Role: ");
                string role = Console.ReadLine()!;
                user = new AdminUser(id, name, role);
            }
            else
            {
                user = new User(id, name);
            }

            _users.Add(user);
            Console.WriteLine("User added!\n");
        }

        public void ViewUsers()
        {
            if (_users.Count == 0)
            {
                Console.WriteLine("No users found.\n");
                return;
            }

            foreach (var user in _users)
            {
                if (user is AdminUser admin)
                    admin.DisplayAdminInfo();
                else
                    user.DisplayInfo();
            }

            Console.WriteLine();
        }

        public void DeleteUser()
        {
            Console.Write("Enter ID to delete: ");
            int id = int.Parse(Console.ReadLine()!);

            var user = _users.Find(u => u.Id == id);
            if (user != null)
            {
                _users.Remove(user);
                Console.WriteLine("User deleted!\n");
            }
            else
            {
                Console.WriteLine("User not found!\n");
            }
        }
    }
    public class UserController
    {
        private readonly IUserService _service;

        public UserController(IUserService service) => _service = service;

        public void Run()
        {
            while (true)
            {
                Console.WriteLine("1: Add User  2: View Users  3: Delete User  4: Exit");
                Console.Write("Choice: ");
                int choice = int.Parse(Console.ReadLine()!);
                Console.WriteLine();

                switch (choice)
                {
                    case 1: _service.AddUser(); 
                        break;
                    case 2: _service.ViewUsers(); 
                        break;
                    case 3: _service.DeleteUser(); 
                        break;
                    case 4: return;
                    default: Console.WriteLine("Invalid choice\n"); break;
                }
            }
        }
    }
    class Program
    {
        static void Main()
        {
            IUserService service = new UserService(); 
            var controller = new UserController(service);
            controller.Run();
        }
    }
}
