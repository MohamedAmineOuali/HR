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
    
    public partial class InfosBanque
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public InfosBanque()
        {
            this.Employes = new HashSet<Employe>();
        }
    
        public int Id { get; set; }
        public string NumeroCompte { get; set; }
        public Nullable<int> TelBanque { get; set; }
        public Nullable<int> CodeBanque { get; set; }
        public string Domiciliation { get; set; }
        public Nullable<int> CodeGuichet { get; set; }
        public string ReglementPar { get; set; }
        public Nullable<int> CleRIB { get; set; }
        public string IBAN { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Employe> Employes { get; set; }
    }
}