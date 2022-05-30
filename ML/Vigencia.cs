using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML
{
    public class Vigencia
    {
        public int IdVigencia { get; set; }
        public string FechaInicio { get; set; }
        public string FechaFin { get; set; }
        public string FechaCreacion { get; set; }
        public string FechaModificacion { get; set; }
        public ML.Usuario Usuario { get; set; }
        public ML.Poliza Poliza { get; set; }
    }
}
