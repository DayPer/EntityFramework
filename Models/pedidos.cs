using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EntityFramework.Models
{

    public class pedidos
    {
        [Key]
        public int PedID { get; set; }
        public int PedUsu { get; set; }
        public int pedPro { get; set; }
        public float pedVrUnit { get; set; }
        public float PedCant { get; set; }
        public float PedSubtot { get; set; }
        public float PedIVA { get; set; }
        public float PedTotal { get; set; }

    }

}
