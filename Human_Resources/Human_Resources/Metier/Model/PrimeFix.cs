//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Human_Resources.Metier.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class PrimeFix
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PrimeFix()
        {
            this.Prime_Categorie = new HashSet<Prime_Categorie>();
        }
    
        public int Id { get; set; }
        public string Libelle { get; set; }
        public string Type { get; set; }
        public Nullable<decimal> Valeur { get; set; }
        public string Exoneres { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Prime_Categorie> Prime_Categorie { get; set; }
    }
}
