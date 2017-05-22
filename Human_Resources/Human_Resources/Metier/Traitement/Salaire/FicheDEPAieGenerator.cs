using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Human_Resources.Metier.Model;

namespace Human_Resources.Metier.Traitement.Salaire
{
    public class FicheDePaieGenerator : IFicheDePaieGeneretor
    {
        Employe e;
        
        public FicheDePaieGenerator(Employe e)
        {
            this.e = e;
        }

        public string GetDateDebut()
        {
            var month = DateTime.Now.Month;
            var year = DateTime.Now.Year; 

            return "1/"+month+"/"+year;
        }

        public string GetDateFin()
        {
            var month = DateTime.Now.Month;
            var year = DateTime.Now.Year;

            return "30/" + month + "/" + year;   
                }

        public Employe GetEmploye()
        {
            return e;
        }

        public decimal HeureSupplementaire()
        {
            using ( var ctx =new HumanResourcesEntities())
            {
                var h =( from c in ctx.BulletinDePaies where c.Employe.Id == e.Id select c).FirstOrDefault();
                return h.HeureSup; 


            }


        }

        public decimal HeureSupplementaireMontant()
        {

            
                return HeureSupplementaire()*heureSupplementaireTaux();


            
        }

        public decimal heureSupplementaireTaux()
        {
            var montant = e.Contrat.Categorie.TauxH;
            return montant;
        }

        public decimal MontantCNAMPatrenale()
        {
            return SalaireBrute() * TauxCNAMPatrenale();
        }

        public decimal MontantCNAMSalariale()
        {
            return SalaireBrute() * TauxCNAMSalairale();
        }

        public decimal MontantCNRPSPatrenale()
        {
            return SalaireBrute() * TauxCNRPSPatrenale();
        }

        public decimal MontantCNRPSSalariale()
        {
            return SalaireBrute() * TauxCNRPSSalairale();
        }

        public decimal MontantCNSSPatrenale()
        {
            return SalaireBrute() * TauxCNSSPatrenale();
        }

        public decimal MontantCNSSSalariale()
        {
            return SalaireBrute()* TauxCNSSSalairale();
        }

        public decimal MontantIGR()
        {
            return 10;
        }

        public decimal Prime()
        {
            using (var ctx = new HumanResourcesEntities())
            {
                var pf = from p in ctx.Prime_Categorie where p.FK_Categorie == e.Contrat.FK_Categorie select p.PrimeFix;
                var primeFixe = 0M; 
                foreach ( var p in pf)
                {

                    primeFixe +=(decimal) p.Valeur; 

                }
                var primeVar = 0M; 
                foreach ( var p in e.PrimesVariables )
                {
                    primeVar += (decimal) p.Valeur; 
                }
                return primeVar + primeFixe; 

            }
        }

        public decimal SalaireBase()
        {
            return e.Contrat.Categorie.SalaireDeBase;
        }

        public decimal SalaireBaseHeure()
        {
            return SalaireBase() / TauxHoraireSalaireBase();
        }

        public decimal SalaireBrute()
        {
            return SalaireBase() + Prime() + HeureSupplementaireMontant();
        }

        public decimal SalaireNet()
        {
            return SalaireBrute() - TotaleSalariale();
        }

        public decimal TauxCNAMPatrenale()
        {
            return e.Contrat.Categorie.CNAM.TauxPatronal.Value; 
        }

        public decimal TauxCNAMSalairale()
        {

            return   e.Contrat.Categorie.CNAM.TauxSalarial.Value; 
            
        }

        public decimal TauxCNRPSPatrenale()
        {
            return e.Contrat.Categorie.CNRP.TauxPatronal.Value;
        }

        public decimal TauxCNRPSSalairale()
        {
            return e.Contrat.Categorie.CNRP.TauxSalarial.Value;
        }

        public decimal TauxCNSSPatrenale()
        {
            return e.Contrat.Categorie.CNSS.TauxPatronal.Value;
        }

        public decimal TauxCNSSSalairale()
        {
            return e.Contrat.Categorie.CNSS.TauxSalarial.Value;
        }

        public decimal TauxHoraireSalaireBase()
        {
            return e.Contrat.Categorie.TauxH;
        }

        public decimal TauxIGR()
        {
            return 10;
        }

        public decimal TotalePatrenal()
        {
            return MontantCNAMPatrenale() + MontantCNRPSPatrenale() + MontantCNSSPatrenale();
        }

        public decimal TotaleSalariale()
        {
            return MontantCNAMSalariale() + MontantCNRPSSalariale() + MontantCNSSSalariale();
        }
    }
}