using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ML
{
    public class Usuario
    {
        public int IdUsuario { get; set; }
        //[Required(ErrorMessage = "Ingrese un nombre de usuario")]
        public string UserName { get; set; }
        //[Required(ErrorMessage = "Ingrese un nombre")]
        public string Nombre { get; set; }
        //[Required(ErrorMessage = "Ingrese un apellido paterno")]
        public string ApellidoPaterno { get; set; }
        //[Required(ErrorMessage = "Ingrese un apellido materno")]
        public string ApellidoMaterno { get; set; }
        //[Required(ErrorMessage = "Ingrese el email")]
        public string Email { get; set; }
        //[Required(ErrorMessage = "Ingrese el sexo")]
        public string Sexo { get; set; }
        //[Required(ErrorMessage = "Ingrese un número de telefono")]
        public string Telefono { get; set; }
        public string Celular { get; set; }
        //[Required(ErrorMessage = "Ingrese la fecha de nacimiento")]
        public  string FechaNacimiento { get; set; }
        //[Required(ErrorMessage = "Ingrese el CURP")]
        public string  Curp { get; set; }
        public List<object> Usuarios { get; set; }
        public string NombreCompleto { get; set; }
        public byte[] Imagen { get; set; }
        //[Required(ErrorMessage = "Ingrese la contraseña")]
        public string Password { get; set; }
        public bool Status { get; set; }
        public ML.Rol Rol { get; set; }
        public ML.Direccion Direccion { get; set; }
        public ML.Colonia Colonia { get; set; }
        public ML.Municipio Municipio { get; set; }
        public ML.Estado Estado { get; set; }
        public ML.Pais Pais { get; set; }
        public string ToXml { get; set; }
    }
}
