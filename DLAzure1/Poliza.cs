//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DLAzure1
{
    using System;
    using System.Collections.Generic;
    
    public partial class Poliza
    {
        public Poliza()
        {
            this.Empleadoes = new HashSet<Empleado>();
            this.EmpresaPolizas = new HashSet<EmpresaPoliza>();
            this.Vigencias = new HashSet<Vigencia>();
        }
    
        public int IdPoliza { get; set; }
        public string Nombre { get; set; }
        public Nullable<int> IdSubPoliza { get; set; }
        public string NumeroPoliza { get; set; }
        public Nullable<System.DateTime> FechaCreacion { get; set; }
        public Nullable<System.DateTime> FechaModificacion { get; set; }
        public Nullable<int> IdUsuario { get; set; }
    
        public virtual ICollection<Empleado> Empleadoes { get; set; }
        public virtual ICollection<EmpresaPoliza> EmpresaPolizas { get; set; }
        public virtual SubPoliza SubPoliza { get; set; }
        public virtual Usuario Usuario { get; set; }
        public virtual ICollection<Vigencia> Vigencias { get; set; }
    }
}
