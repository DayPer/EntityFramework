using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EntityFramework.Models
{
 
        public class account
    {
            public int id { get; set; }
            public string clientId { get; set; }
            public string account_num { get; set; }
            public string account_type { get; set; }
            public Int64 start_balance { get; set; }
            public bool state { get; set; }

    }

}
