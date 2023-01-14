using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EntityFramework.Models
{

    public class usuarios
    {
        [Key]
        public int UsuID { get; set; }
        public string UsuNombre { get; set; }
        public string UsuPass { get; set; }

    }

}
