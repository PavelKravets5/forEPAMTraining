using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace TodoApi5.Models
{
        [DataContract]
        public class EmailsModel
        {
            [DataMember(Name = "Id")]
            public int Id { get; set; }

            [DataMember(Name = "OrganizerId")]
            public int OrganizerId { get; set; }

            [DataMember(Name = "Email")]
            public string Email { get; set; }
        }
}
