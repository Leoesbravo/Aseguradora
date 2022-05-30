using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ML
{
    public class Direccion
    {
        public int IdDireccion { get; set; }
        [Required(ErrorMessage = "Ingrese la calle")]
        public string Calle { get; set; }
        [Required(ErrorMessage = "Ingrese el numero interior")]
        public string NumeroExterior { get; set; }
        public string NumeroInterior { get; set; }
        public ML.Colonia Colonia { get; set; }
        public ML.Usuario Usuario { get; set; }
    }
}
