    using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ML
{
    public class Empleado
    {
        [Required(ErrorMessage = "Ingrese un numero de empleado")]
        public string NumeroEmpleado { get; set; }
        [Required(ErrorMessage = "Ingrese el RFC")]
        public string RFC { get; set; }
        //[Required(ErrorMessage = "Ingrese un nombre de empleado")]
        public string Nombre { get; set; }
        //[Required(ErrorMessage = "Ingrese el apellido paterno del empleado")]
        public string ApellidoPaterno { get; set; }
        //[Required(ErrorMessage = "Ingrese el apellido materno del empleado")]
        public string ApellidoMaterno { get; set; }
        [Required(ErrorMessage = "Ingrese el email")]
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "el Email no es valido")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Ingrese el numero")]
        public string Telefono { get; set; }
        [Required(ErrorMessage = "Ingrese la fecha de nacimiento")]
        public string FechaNacimiento { get; set; }
        [Required(ErrorMessage = "Ingrese el NSS")]
        public string NSS { get; set; }
        public string FechaIngreso { get; set; }
        public byte[] Foto { get; set; }
        public ML.Empresa empresa { get; set; }
        public List<object> Empleados { get; set; }
        public string Action { get; set; }

    }
}
