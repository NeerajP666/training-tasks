using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace RESTAUTH2
{
    public class AuthRequest
    {
        [DataMember] public string Username { get; set; }
        [DataMember] public string Password { get; set; }
        [DataMember]
        public string Role { get; set; }
    }

    [DataContract]
    public class AuthResponse
    {
        [DataMember] public bool Success { get; set; }
        [DataMember] public string Message { get; set; }
        [DataMember]
        public string Role { get; set; }
    }
}