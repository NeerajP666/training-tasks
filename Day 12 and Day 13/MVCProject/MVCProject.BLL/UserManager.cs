using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVCProject.DAL;

namespace MVCProject.BLL
{
    public class UserManager
    {
        private readonly UserRepository repo = new UserRepository();

        public bool Register(string username, string password)
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
                return false;

            return repo.RegisterUser(username, password);
        }

        public bool Login(string username, string password)
        {
            return repo.ValidateUser(username, password);
        }
    }

}
