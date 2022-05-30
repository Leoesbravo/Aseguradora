using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ML
{
   public class SubPoliza
    {
        public int IdSubPoliza { get; set; }
        [Required(ErrorMessage = "Ingrese un nombre")]
        public string Nombre { get; set; }
        public List<object> Subpolizas { get; set; }
    }
}
