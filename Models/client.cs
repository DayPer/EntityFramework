using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EntityFramework.Models
{
    public class client
    {
        public int id { get; set; }
        public string clientId { get; set; }
        public string password { get; set; }
        public bool state { get; set; }
    }
}
