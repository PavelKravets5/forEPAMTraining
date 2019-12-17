using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Drawing;

namespace TodoApi5.Models
{
    [DataContract]
    public class MyEventsModel
    {
        [DataMember(Name = "Id")]
        public int Id { get; set; }

        [DataMember(Name = "EventTitle")]
        public string EventTitle { get; set; }

        [DataMember(Name = "EventDate")]
        public DateTime EventDate { get; set; }

        [DataMember(Name = "Category")]
        public string Category { get; set; }

        [DataMember(Name = "Picture")]
        public string Picture { get; set; }

        [DataMember(Name = "Screen_format")]
        public string Screen_format { get; set; }

        [DataMember(Name = "EventVenue")]
        public string EventVenue { get; set; }

        [DataMember(Name = "Discription")]
        public string Discription { get; set; }



        [DataMember(Name = "Organizer")]
        public string Organizer { get; set; }
    }
}
