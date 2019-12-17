using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace TodoApi5.Models
{
    [DataContract]
    public class OrganizersModel
    {
        [DataMember(Name = "Id")]
        public int Id { get; set; }

        [DataMember(Name = "Organizer")]
        public string Organizer { get; set; }

        [DataMember(Name = "Adress")]
        public string Adress { get; set; }
    }
}