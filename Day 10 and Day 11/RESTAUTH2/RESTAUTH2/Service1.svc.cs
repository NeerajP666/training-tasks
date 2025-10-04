using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Web.Security;

namespace RESTAUTH2
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        public AuthResponse Register(AuthRequest request)
        {
           
            try
            {
                MembershipCreateStatus status;
                Membership.CreateUser(request.Username, request.Password, request.Username + "@mail.com", null, null, true, out status);

                if (status == MembershipCreateStatus.Success)
                {
                    string roleToAssign = string.IsNullOrEmpty(request.Role) ? "User" : request.Role;

                    if (!Roles.RoleExists(roleToAssign))
                        Roles.CreateRole(roleToAssign);

                    Roles.AddUserToRole(request.Username, roleToAssign);
                }

                return new AuthResponse
                {
                    Success = (status == MembershipCreateStatus.Success),
                    Message = status.ToString(),
                    Role = string.IsNullOrEmpty(request.Role) ? "User" : request.Role
                };
            }
            catch (Exception ex)
            {
                return new AuthResponse
                {
                    Success = false,
                    Message = "Error: " + ex.Message
                };
            }


        }

        public AuthResponse Login(AuthRequest request)
        {

            bool valid = Membership.ValidateUser(request.Username, request.Password);

            if (valid)
            {
                string[] roles = Roles.GetRolesForUser(request.Username);
                return new AuthResponse
                {
                    Success = true,
                    Message = "Login successful",
                    Role = roles.Length > 0 ? roles[0] : "No role assigned"
                };
            }
            return new AuthResponse
            {
                Success = false,
                Message = "Invalid username or password"
            };

        }
        

    }
}
