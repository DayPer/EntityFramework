using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EntityFramework.Models
{

    public class productos
    {
        [Key]
        public int ProID { get; set; }
        public string ProDesc { get; set; }
        public float ProValor { get; set; }


    }

}
