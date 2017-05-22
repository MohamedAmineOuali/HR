using Human_Resources.Metier.Model;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace Human_Resources.Metier.Traitement.Salaire
{
    public class SalaireManagment
    {

        public Byte[] GeneratePDF(IFicheDePaieGeneretor g, Etablissement etab)
        {
            //Create a byte array that will eventually hold our final PDF
            Byte[] bytes;

            //Boilerplate iTextSharp setup here
            //Create a stream that we can write to, in this case a MemoryStream
            using (var ms = new MemoryStream())
            {

                //Create an iTextSharp Document which is an abstraction of a PDF but **NOT** a PDF
                using (var doc = new Document())
                {
                    
                    //Create a writer that's bound to our PDF abstraction and our stream
                    using (var writer = PdfWriter.GetInstance(doc, ms))
                    {

                        //Open the document for writing
                        doc.Open();

                        //Our sample HTML and CSS

                        Employe e = g.GetEmploye();
                        var example_html = $@"		
<div>
<h1 align='center'> Bulletin de salaire du {g.GetDateDebut()} au {g.GetDateFin()}</h1>

        < div class='adresseSocieter'> {etab.Label}<br> </br>{etab.Localite} </div>


		<div  class='infoEmploye'>
            < table>
				<tr>
					<th>Nom:</th> <td> {e.Nom}</td>
				</tr>
				<tr>
					<th> Prenom:</th> <td> {e.Prenom} </td>
				</tr>

				<tr>
					<th>Position:</th> <td> {e.Contrat.Categorie.Libelle}</td>
				</tr>
				<tr>
					<th> Adresse: </th>
					<td> {e.Addresse}</td>
				</tr>
			</table>
		</div>

        <div>
		    <div class='infoGenerale' id='g'>
	            <table  >
		            <tr>
			            <td class='noborder'></td><th class='t l'>Heures</th><th class='t'>Taux horaire</th><th class='t r' >Montant</th>
		            </tr>
		            <tr>
			            <th class='t l'>Salaire de base</th><td>{g.SalaireBaseHeure()}</td><td>{g.TauxHoraireSalaireBase()}</td><td class='r'>{g.SalaireBase()}</td>
		            </tr>
		            <tr>
			            <th class='l'>H.S</th><td>{g.HeureSupplementaire()}</td><td>{g.heureSupplementaireTaux()}</td><td class='r'>{g.HeureSupplementaireMontant()}</td>
		            </tr>
		            <tr>
			            <th class='b l'>Primes</th><td colspan='2'></td><td class='r'>{g.Prime()}</td>
		            </tr>
		            <tr>
			            <td class='noborder' ></td><th colspan='2' class='b l'>Salaire brut</th><td class='r b'>{g.SalaireBrute()}</td>
                    </tr>
			    </table>
		    </div>
        </div>

		<div  class='infoGenerale' >
		
	<table align='center'>
		<tr>
			<td class='noborder'></td >  <td class='noborder'></td><th  class='t l' colspan='2'>Cotisations Salariales</th><th class='t r' colspan='2'>Charges Patronales</th>
		</tr>
		<tr>
			<td class='noborder'></td><th class='t l'>Base</th><th>Taux</th><th>Montant</th><th>Taux</th><th class='r'>Montant</th>
		</tr>
		<tr>
			<th class='t l'>Sécurité Sociale</th><td>{g.SalaireBrute()}</td><td>{g.TauxCNSSSalairale()}</td><td>{g.MontantCNSSSalariale()}</td><td>{g.TauxCNSSPatrenale()}</td><td class='r'>{g.MontantCNSSPatrenale()}</td>
		</tr>
		<tr>
			<th class='l'>Cotisations non plafonnées</th><td>{g.SalaireBrute()}</td><td>{g.TauxCNRPSSalairale()}</td><td>{g.MontantCNRPSSalariale()}</td><td>{g.TauxCNRPSPatrenale()}</td><td class='r'>{g.MontantCNRPSPatrenale()}</td>
		</tr>
		<tr>
			<th class='l b'>Retraite complémentaire</th><td class='b'>{g.SalaireBrute()}</td><td>{g.TauxCNAMSalairale()}</td><td>{g.MontantCNAMSalariale()}</td><td>{g.TauxCNAMPatrenale()}</td><td class='r'>{g.MontantCNAMPatrenale()}</td>
		</tr>M
		<tr>
			<td class='noborder'></td><td class='noborder'></td><th class='l b'>Total</th><td class='b'>{g.TotaleSalariale()}</td><th class='b'>total</th><td class='r b'>{g.TotalePatrenal()}</td>
		</tr>
		</table>
		</div>


		<div  class='infoGenerale' >

			<table border=1 align='right' id=tt>
			<tr><th>Taux IGR</th><td>{g.TauxIGR()}</td></tr>
			<tr><th>Salaire net</th><td>{g.SalaireNet()}</td></tr>
		</table>	
		</div>

</div>";

                        /**************************************************
                         * Example #3                                     *
                         *                                                *
                         * Use the XMLWorker to parse HTML and CSS        *
                         * ************************************************/

                        //In order to read CSS as a string we need to switch to a different constructor
                        //that takes Streams instead of TextReaders.
                        //Below we convert the strings into UTF8 byte array and wrap those in MemoryStreams
                        using (var msCss = new MemoryStream(System.Text.Encoding.UTF8.GetBytes(example_css)))
                        {
                            using (var msHtml = new MemoryStream(System.Text.Encoding.UTF8.GetBytes(example_html)))
                            {

                                //Parse the HTML
                                iTextSharp.tool.xml.XMLWorkerHelper.GetInstance().ParseXHtml(writer, doc, msHtml, msCss);
                            }
                        }


                        doc.Close();
                    }
                }

                //After all of the PDF "stuff" above is done and closed but **before** we
                //close the MemoryStream, grab all of the active bytes from the stream
                bytes = ms.ToArray();
            }


            return bytes;
        }



        string example_css = @"

             h1
            {
                align:center;
                font-size:28px;
               font-weight:bold;
                padding-bottom:100%;
            }

            .adresseSocieter
            {
                margin-top:20px;
                float:left;
                width:20%;
            }

            th
            {
               font-weight:bold;
            }

            table
            {
                    border-collapse: collapse;
            }

            .infoEmploye
			{
                margin-top:50px;
                width:53%;
                float:right;
			}

            .infoEmploye th
            {
                border-bottom: 1px solid #ddd;
            }

            .infoEmploye td
			{
                padding-left:15%;
                width:250px;
			}

            .infoEmploye td, .infoEmploye th
            {
                padding-top:9px;
            }

            #g
            {
                float:right;
            }

            #g table
            {   
                 margin-top:20px;
            }
            
            .infoGenerale th
            {
                background-color: #eee;
            }
            .infoGenerale table
            {
                 margin-top:10px;
            }

             .infoGenerale th, .infoGenerale td 
			{
                padding-right: 10px;
				padding-left:5px;
                padding-bottom:6px;
                padding-top:6px;

				border: 0.1px solid black;
			}

            .infoGenerale .noborder
            {
                border:0px;
                visibility:hidden;
            }
            
            .infoGenerale .r     
            {
                border-right: 1.5px solid black;
            }
            
            .infoGenerale .l     
            {
                border-left: 1.5px solid black;
            }

            .infoGenerale .t     
            {
                border-top: 1.5px solid black;
            }

            .infoGenerale .b  
            {
                border-bottom: 1.5px solid black;
            }            


";
    }
}