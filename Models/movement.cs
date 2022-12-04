using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EntityFramework.Models
{
 
        public class movement
        {
         public int id { get; set; }

         public string date { get; set; }

         public string clientid { get; set; }

        public string account_number { get; set; }

        public string account_type  { get; set; }

        public string movement_type { get; set; }

        public Int64 amount { get; set; }

        public Int64 balance { get; set; }

        public bool state { get; set; }

        public Int64 start_balance { get; set; }

    }

}
