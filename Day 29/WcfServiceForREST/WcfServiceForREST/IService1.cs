using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WcfServiceForREST
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService1
    {
        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "/register", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        string Register(UserCredentials user);

        [OperationContract]
        [WebInvoke(Method ="POST",UriTemplate ="/login",RequestFormat =WebMessageFormat.Json,ResponseFormat =WebMessageFormat.Json)]
        bool Login(UserCredentials user);
        
    }
}
