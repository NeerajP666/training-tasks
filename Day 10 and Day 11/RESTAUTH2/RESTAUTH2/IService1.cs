using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace RESTAUTH2
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService1
    {
        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "/register", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        AuthResponse Register(AuthRequest request);

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "/login", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        AuthResponse Login(AuthRequest request);



    }



}
