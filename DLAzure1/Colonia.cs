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
    
    public partial class Colonia
    {
        public Colonia()
        {
            this.Direccions = new HashSet<Direccion>();
        }
    
        public int IdColonia { get; set; }
        public string Nombre { get; set; }
        public string CodigoPostal { get; set; }
        public Nullable<int> IdMunicipio { get; set; }
    
        public virtual Municipio Municipio { get; set; }
        public virtual ICollection<Direccion> Direccions { get; set; }
    }
}
