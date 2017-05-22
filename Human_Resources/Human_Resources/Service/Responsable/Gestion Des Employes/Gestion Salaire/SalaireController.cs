using Human_Resources.Metier.Model;
using Human_Resources.Metier.Traitement.Salaire;
using Human_Resources.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Web.Http;

namespace Human_Resources.Service.Responsable.Gestion_Des_Employes.GEstion_Salaire
{
    [RoutePrefix("api/Employees/Salaire")]
    public class SalaireController : ApiController
    {
        private HumanResourcesEntities db = new HumanResourcesEntities();
        private SalaireManagment manager=new SalaireManagment();


        [Authorize]
        [Route("fichedepaie/{id:int}")]
        [HttpGet]
        public HttpResponseMessage GenerateFicheDePaiePDF(int id)
        {
            Employe e = db.Employes.Find(id);
            var curUser = new UserCompte((ClaimsIdentity)User.Identity);
            Compte c = db.Comptes.Find(curUser.Id);

            Byte[] bytes = manager.GeneratePDF(new FicheDePaieGenerator(e),c.Etablissement);


            dynamic obj = new ExpandoObject();
            obj.file = Convert.ToBase64String(bytes) ;

            return Request.CreateResponse(HttpStatusCode.OK, (Object) obj);
        }
    }
}
