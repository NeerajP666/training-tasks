using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace WcfServiceForREST
{
    [DataContract]
    public class UserCredentials
    {
        [DataMember]
        public string UserName{ get; set; }
        [DataMember]
        public string Password{ get; set; }
        [DataMember]
        public string Email { get; set; }
        [DataMember]
        public string PasswordQuestion { get; set; }

        [DataMember]
        public string PasswordAnswer { get; set; }

    }
}