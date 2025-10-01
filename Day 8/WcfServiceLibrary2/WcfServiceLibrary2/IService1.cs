using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WcfServiceLibrary2
{
    [ServiceContract]
    public interface IService1
    {
        [OperationContract]
        bool RegisterUser(User user);

        [OperationContract]
        bool LoginUser(string username, string password);
        [OperationContract]
        int GetNextUserID();
    }


}
