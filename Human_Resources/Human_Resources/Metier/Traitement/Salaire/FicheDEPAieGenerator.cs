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
            return "01/11/2016";
        }

        public string GetDateFin()
        {
            return "30/11/2017";
        }

        public Employe GetEmploye()
        {
            return e;
        }

        public decimal HeureSupplementaire()
        {
            return 10;
        }

        public decimal HeureSupplementaireMontant()
        {
            return 10;
        }

        public decimal heureSupplementaireTaux()
        {
            return 10;
        }

        public decimal MontantCNAMPatrenale()
        {
            return 10;
        }

        public decimal MontantCNAMSalariale()
        {
            return 10;
        }

        public decimal MontantCNRPSPatrenale()
        {
            return 10;
        }

        public decimal MontantCNRPSSalariale()
        {
            return 10;
        }

        public decimal MontantCNSSPatrenale()
        {
            return 10;
        }

        public decimal MontantCNSSSalariale()
        {
            return 10;
        }

        public decimal MontantIGR()
        {
            return 10;
        }

        public decimal Prime()
        {
            return 10;
        }

        public decimal SalaireBase()
        {
            return 10;
        }

        public decimal SalaireBaseHeure()
        {
            return 10;
        }

        public decimal SalaireBrute()
        {
            return 10;
        }

        public decimal SalaireNet()
        {
            return 10;
        }

        public decimal TauxCNAMPatrenale()
        {
            return 10;
        }

        public decimal TauxCNAMSalairale()
        {
            return 10;
        }

        public decimal TauxCNRPSPatrenale()
        {
            return 10;
        }

        public decimal TauxCNRPSSalairale()
        {
            return 10;
        }

        public decimal TauxCNSSPatrenale()
        {
            return 10;
        }

        public decimal TauxCNSSSalairale()
        {
            return 10;
        }

        public decimal TauxHoraireSalaireBase()
        {
            return 10;
        }

        public decimal TauxIGR()
        {
            return 10;
        }

        public decimal TotalePatrenal()
        {
            return 10;
        }

        public decimal TotaleSalariale()
        {
            return 10;
        }
    }
}