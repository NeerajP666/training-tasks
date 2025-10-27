using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Security;
using System.ServiceModel.Web;
using System.Text;
using System.Web.Security;

namespace WcfServiceForREST
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        public string Register(UserCredentials user)
        {
            MembershipCreateStatus status;
            Membership.CreateUser(user.UserName, user.Password, user.Email, user.PasswordQuestion,user.PasswordAnswer, true, out status);
            //return status == MembershipCreateStatus.Success;

            return status.ToString();

        }
        public bool Login(UserCredentials user)
        {
            return Membership.ValidateUser(user.UserName, user.Password);
        }
    }
}
