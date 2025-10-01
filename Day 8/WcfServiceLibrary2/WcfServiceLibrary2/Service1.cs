using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WcfServiceLibrary2
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public class Service1 : IService1
    {
        UserDAL userDAL = new UserDAL();

        public bool RegisterUser(User user)
        {
            return userDAL.Register(user);
        }

        public bool LoginUser(string username, string password)
        {
            return userDAL.Login(username, password);
        }
        public int GetNextUserID()
        {
            string query = "select isnull(max(userid), 0) + 1 from users";
            return Convert.ToInt32(UserDAL.ExecuteScalar(query, null));
        }
    }
}
