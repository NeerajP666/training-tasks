using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;




namespace UserServiceWCF
{
    public class Service1 : IService1
    {
        private readonly UserDAL dal = new UserDAL();

        public bool Register(User user)
        {
            return dal.Register(user.username, user.password, user.email);
        }

        public bool Login(User user)
        {
            return dal.Login(user.username, user.password);

        }
        public int GetNextUserID()
        {
            UserDAL dal = new UserDAL();
            return dal.GetNextUserID();
        }
    }
}
