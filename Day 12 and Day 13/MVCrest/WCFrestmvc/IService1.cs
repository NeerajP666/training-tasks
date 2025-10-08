
using System.ServiceModel;
using System.ServiceModel.Web;

namespace WCFrestmvc
{
    [ServiceContract]
    public interface IService1
    {
        [OperationContract]
        [WebInvoke(
            Method = "POST",
            UriTemplate = "/Register",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Bare)]
        bool Register(User user);

        [OperationContract]
        [WebInvoke(
            Method = "POST",
            UriTemplate = "/Login",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Bare)]
        bool Login(User user);

        [OperationContract]
        [WebGet(
            UriTemplate = "/GetNextUserID",
            ResponseFormat = WebMessageFormat.Json)]
        int GetNextUserID();

        [OperationContract]
        [WebInvoke(Method = "OPTIONS", UriTemplate = "*")]
        void GetOptions();
    }
}
