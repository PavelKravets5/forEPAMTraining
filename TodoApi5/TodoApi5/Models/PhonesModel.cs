using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace TodoApi5.Models
{
    [DataContract]
    public class PhonesModel
    {
        [DataMember(Name = "Id")]
        public int Id { get; set; }

        [DataMember(Name = "OrganizerId")]
        public int OrganizerId { get; set; }

        [DataMember(Name = "Phone")]
        public string Phone { get; set; }
    }
}
