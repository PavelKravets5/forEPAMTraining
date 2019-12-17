using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TodoApi5.Models
{
    public class MySettingsModel
    {
        public string DbConnection { get; set; }
        public string Email { get; set; }
        public string SMTPPort { get; set; }
        public string Secret { get; set; }
    }
}
