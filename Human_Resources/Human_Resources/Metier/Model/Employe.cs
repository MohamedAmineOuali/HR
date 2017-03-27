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
    
    public partial class Employe
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Employe()
        {
            this.Avances = new HashSet<Avance>();
            this.BulletinDePaies = new HashSet<BulletinDePaie>();
            this.Comptes = new HashSet<Compte>();
            this.Conges = new HashSet<Conge>();
            this.Departements = new HashSet<Departement>();
            this.PrimesVariables = new HashSet<PrimesVariable>();
        }
    
        public int Id { get; set; }
        public string Nom { get; set; }
        public string Addresse { get; set; }
        public string Prenom { get; set; }
        public Nullable<int> NbreEnfants { get; set; }
        public string LieuDeNaissance { get; set; }
        public Nullable<System.DateTime> DateDeNaissance { get; set; }
        public Nullable<int> CIN { get; set; }
        public Nullable<int> Matricule { get; set; }
        public string StatutSocial { get; set; }
        public Nullable<int> Telephone { get; set; }
        public string Natonalite { get; set; }
        public Nullable<int> Num_SecuriteSociale { get; set; }
        public string Grade { get; set; }
        public string Genre { get; set; }
        public string Etat { get; set; }
        public Nullable<int> FK_InfosBanque { get; set; }
        public Nullable<int> FK_Contrat { get; set; }
        public Nullable<int> FK_Departement { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Avance> Avances { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BulletinDePaie> BulletinDePaies { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Compte> Comptes { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Conge> Conges { get; set; }
        public virtual Contrat Contrat { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Departement> Departements { get; set; }
        public virtual Departement Departement { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PrimesVariable> PrimesVariables { get; set; }
        public virtual InfosBanque InfosBanque { get; set; }
    }
}
