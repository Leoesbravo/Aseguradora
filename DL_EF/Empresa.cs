//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DL_EF
{
    using System;
    using System.Collections.Generic;
    
    public partial class Empresa
    {
        public Empresa()
        {
            this.Empleadoes = new HashSet<Empleado>();
            this.EmpresaPolizas = new HashSet<EmpresaPoliza>();
        }
    
        public int IdEmpresa { get; set; }
        public string Nombre { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
        public string DireccionWeb { get; set; }
        public byte[] Logo { get; set; }
    
        public virtual ICollection<Empleado> Empleadoes { get; set; }
        public virtual ICollection<EmpresaPoliza> EmpresaPolizas { get; set; }
    }
}
