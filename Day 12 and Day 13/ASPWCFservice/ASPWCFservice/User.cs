using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace ASPWCFservice
{
    [DataContract]
    public class User
    {
        [DataMember]
        public int userid { get; set; }

        [DataMember]
        public string username { get; set; }

        [DataMember]
        public string password { get; set; }

        [DataMember]
        public string email { get; set; }
    }
}