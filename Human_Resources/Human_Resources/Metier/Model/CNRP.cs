//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré à partir d'un modèle.
//
//     Des modifications manuelles apportées à ce fichier peuvent conduire à un comportement inattendu de votre application.
//     Les modifications manuelles apportées à ce fichier sont remplacées si le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Human_Resources.Metier.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class CNRP
    {
        public int Id { get; set; }
        public Nullable<decimal> TauxPatronal { get; set; }
        public Nullable<decimal> TauxSalarial { get; set; }
    
        public virtual Categorie Categorie { get; set; }
    }
}
