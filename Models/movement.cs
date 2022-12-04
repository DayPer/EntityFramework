using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EntityFramework.Models
{
 
        public class movement
        {
            public int id { get; set; }

            public string clientid { get; set; }

            public DateTime date { get; set; }

            public string movement_type { get; set; }
            public Int64 value { get; set; }

            public Int64 balance { get; set; }
    }
    
}
