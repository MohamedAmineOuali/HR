using Human_Resources.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Http;
using System.Net.Http;
using System.Net;
using Human_Resources.Metier.Traitement;
using System.Security.Claims;
using Human_Resources.Metier.Model;
using Human_Resources.Model.FileUpload;

namespace Human_Resources.Service.Responsable.Gestion_Des_Employes
{

    [RoutePrefix("api/Employee")]
    public class UploadController : ApiController
    {
        EmployeesManager em = new EmployeesManager();
        private HumanResourcesEntities db = new HumanResourcesEntities();


        //[Authorize]
        [Route("UploadFile")]// POST: api/Upload
        public HttpResponseMessage Post([FromBody]FileUploadData request)
        {
            if(!request.Verify())
            {
                var message = string.Format("File forma is not allowed");
                HttpError err = new HttpError(message);
                return Request.CreateResponse(HttpStatusCode.NotAcceptable, err);
            }

            var curUser = new UserCompte((ClaimsIdentity)User.Identity);
            var detail = new UploadDetails();

           
            detail.Etablissements = db.Etablissements.Include("Departements").ToList();

            foreach(var e in detail.Etablissements)
            {
                e.Departements=null;
            }

            detail.File =em.SaveFile(request.GetFileBytes());

            return Request.CreateResponse(HttpStatusCode.OK,detail);
        }

        //[Authorize]
        [Route("GenerateData/{id:int}")]// POST: api/Upload/{id}
        public HttpResponseMessage Post(int id, [FromBody]ExcelFile FileDetails)
        {
            em.GenerateData(FileDetails,id);

            return Request.CreateResponse(HttpStatusCode.OK);
        }

    }
}
