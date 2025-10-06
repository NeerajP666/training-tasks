using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace ASPWCFservice
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
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
