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
    
    public partial class Compte
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public Nullable<int> FK_Employe { get; set; }
        public Nullable<int> FK_Role { get; set; }
    
        public virtual Employe Employe { get; set; }
        public virtual Role Role { get; set; }
    }
}
