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
    
    public partial class Aseguradora
    {
        public int IdAseguradora { get; set; }
        public string Nombre { get; set; }
        public Nullable<System.DateTime> FechaCreacion { get; set; }
        public Nullable<System.DateTime> FechaModificacion { get; set; }
        public Nullable<int> IdUsuario { get; set; }
    
        public virtual Usuario Usuario { get; set; }
    }
}
