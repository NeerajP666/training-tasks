using System.Runtime.Serialization;

namespace WCFrestmvc
{
    [DataContract]
    public class User
    {
        

        [DataMember]
        public string username { get; set; }

        [DataMember]
        public string password { get; set; }

        [DataMember]
        public string email { get; set; }
    }
}
