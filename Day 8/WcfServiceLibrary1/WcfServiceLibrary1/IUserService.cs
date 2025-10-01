using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WcfServiceLibrary1
{
    [ServiceContract]
    public interface IUserService
    {
        [OperationContract]
        bool RegisterUser(User user);

        [OperationContract]
        bool LoginUser(string username, string password);
    }

}
