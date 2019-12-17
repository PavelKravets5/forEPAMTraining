using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace TodoApi5.Models
{
    [DataContract]
    public class CategoriesModel
    {
        [DataMember(Name = "Id")]
        public int Id { get; set; }

        [DataMember(Name = "Category")]
        public string Category { get; set; }
    }
}
