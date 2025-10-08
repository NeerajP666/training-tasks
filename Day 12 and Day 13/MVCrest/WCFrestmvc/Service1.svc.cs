

using System.ServiceModel.Web;

namespace WCFrestmvc
{
    public class Service1 : IService1
    {
        private readonly UserDAL dal = new UserDAL();

        private void AddCorsHeaders()
        {
            var headers = WebOperationContext.Current.OutgoingResponse.Headers;
            headers.Add("Access-Control-Allow-Origin", "*");
            headers.Add("Access-Control-Allow-Methods", "GET, POST, PUT, DELETE, OPTIONS");
            headers.Add("Access-Control-Allow-Headers", "Content-Type, Accept");
        }

        public bool Register(User user)
        {
            AddCorsHeaders();
            return dal.Register(user.username, user.password, user.email);
        }

        public bool Login(User user)
        {
            AddCorsHeaders();
            return dal.Login(user.username, user.password);
        }

        public int GetNextUserID()
        {
            AddCorsHeaders();
            return dal.GetNextUserID();
        }

        public void GetOptions()
        {
            AddCorsHeaders();
        }
    }
}
