using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EntityFramework.Models
{
    public class transaction
    {
        public int id { get; set; }
        public string account_number { get; set; }
        public Int64 amount { get; set; }
        public string operation { get; set; }
    }
}
