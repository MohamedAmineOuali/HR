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
    
    public partial class PrimesVariable
    {
        public int Id { get; set; }
        public string Libelle { get; set; }
        public string Type { get; set; }
        public Nullable<decimal> Valeur { get; set; }
        public string Exoneres { get; set; }
        public Nullable<System.DateTime> DateAffectation { get; set; }
        public int FK_Employe { get; set; }
    
        public virtual Employe Employe { get; set; }
    }
}
