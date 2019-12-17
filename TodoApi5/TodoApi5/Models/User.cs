using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace TodoApi5.Models
{
    [DataContract]
    public class User
    {
        [DataMember(Name = "Id")]
        public int Id { get; set; }

        [DataMember(Name = "FirstName")]
        public string FirstName { get; set; }

        [DataMember(Name = "LastName")]
        public string LastName { get; set; }

        [DataMember(Name = "Username")]
        public string Username { get; set; }

        [DataMember(Name = "Password")]
        public string Password { get; set; }

        [DataMember(Name = "Role")]
        public string Role { get; set; }

        [DataMember(Name = "Token")]
        public string Token { get; set; }
    }
}
