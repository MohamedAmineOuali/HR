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
    
    public partial class Prime_Categorie
    {
        public int Id { get; set; }
        public int FK_Categorie { get; set; }
        public int FK_PrimeFixe { get; set; }
    
        public virtual Categorie Categorie { get; set; }
        public virtual PrimeFix PrimeFix { get; set; }
    }
}
