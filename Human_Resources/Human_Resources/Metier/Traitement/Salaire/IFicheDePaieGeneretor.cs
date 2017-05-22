

using Human_Resources.Metier.Model;

namespace Human_Resources.Metier.Traitement.Salaire
{
     public interface IFicheDePaieGeneretor
    {
        string GetDateDebut();
        string GetDateFin();
        Employe GetEmploye();

        decimal SalaireBaseHeure();
        decimal TauxHoraireSalaireBase();
        decimal SalaireBase();
        decimal HeureSupplementaire();
        decimal heureSupplementaireTaux();
        decimal HeureSupplementaireMontant();
        decimal Prime();
        decimal SalaireBrute();

        decimal TauxCNSSSalairale();
        decimal MontantCNSSSalariale();
        decimal TauxCNSSPatrenale();
        decimal MontantCNSSPatrenale();


        decimal TauxCNRPSSalairale();
        decimal MontantCNRPSSalariale();
        decimal TauxCNRPSPatrenale();
        decimal MontantCNRPSPatrenale();

        decimal TauxCNAMSalairale();
        decimal MontantCNAMSalariale();
        decimal TauxCNAMPatrenale();
        decimal MontantCNAMPatrenale();

        decimal TotalePatrenal();
        decimal TotaleSalariale();

        decimal TauxIGR();
        decimal MontantIGR();


        decimal SalaireNet();


    }
}
