using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Human_Resources.Metier.Model;
namespace Human_Resources.Model
{
    public class EmployeeAllInfo
    {
        public Employe GetEmployee(List<Departement> departements, List<TypeContrat> typeContrats)
        {
            InfosBanque infoBanque = new InfosBanque
            {
                NumeroCompte = NumeroCompte,
                TelBanque = TelBanque,
                CodeBanque = CodeBanque,
                Domiciliation = Domiciliation,
                CodeGuichet = CodeGuichet,
                ReglementPar = ReglementPar,
                CleRIB = CleRIB,
                IBAN = IBAN
            };
            var typeContrat= typeContrats.Where(t => t.Type ==TypeContrat).FirstOrDefault();

            Contrat contrat = new Contrat()
            {
                Numero = NumeroContrat,
                DateDebut = DateDebut,
                DateFin = DateFin,
                TypeContrat = typeContrat
            };

            var departement = departements.Where(t => t.Libelle == Departement).FirstOrDefault();


            Employe employe = new Employe
            {
                Nom = Nom,
                Addresse = Addresse,
                Prenom = Prenom,
                NbreEnfants = NbreEnfants,
                LieuDeNaissance = LieuDeNaissance,
                DateDeNaissance = DateDeNaissance,
                CIN = CIN,
                Matricule = Matricule,
                StatutSocial = StatutSocial,
                Telephone = Telephone,
                Natonalite = Natonalite,
                Num_SecuriteSociale = Num_SecuriteSociale,
                Grade = Grade,
                Genre = Genre,
                Etat = Etat,
                InfosBanque=infoBanque,
                Departement=departement,
                Contrat=contrat
            };
            return employe;
        }

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

        public string NumeroCompte { get; set; }
        public Nullable<int> TelBanque { get; set; }
        public Nullable<int> CodeBanque { get; set; }
        public string Domiciliation { get; set; }
        public Nullable<int> CodeGuichet { get; set; }
        public string ReglementPar { get; set; }
        public Nullable<int> CleRIB { get; set; }
        public string IBAN { get; set; }


        public string NumeroContrat { get; set; }
        public Nullable<System.DateTime> DateDebut { get; set; }
        public Nullable<System.DateTime> DateFin { get; set; }
        public string TypeContrat { get; set; }

        public string Departement { get; set; }

    }
}