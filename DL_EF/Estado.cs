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
    
    public partial class Estado
    {
        public Estado()
        {
            this.Municipios = new HashSet<Municipio>();
        }
    
        public int IdEstado { get; set; }
        public string Nombre { get; set; }
        public Nullable<int> IdPais { get; set; }
    
        public virtual Pai Pai { get; set; }
        public virtual ICollection<Municipio> Municipios { get; set; }
    }
}
