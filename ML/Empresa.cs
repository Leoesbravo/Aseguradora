using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ML    
{
   public class Empresa
    {
        public int IdEmpresa { get; set; }
        [Required(ErrorMessage = "Ingrese un nombre")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "Ingrese un telefono")]
        public string Telefono { get; set; }
        [Required(ErrorMessage = "Ingrese un Email")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Ingrese una direccion web")]
        public string DireccionWeb { get; set; }
        public byte[] Logo { get; set; }
        public List<object> Empresas { get; set; }
    }
}
