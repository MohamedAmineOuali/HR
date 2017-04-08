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

namespace Human_Resources.Service.Responsable.Gestion_Des_Employes
{

    [RoutePrefix("api/Employee")]
    public class UploadController : ApiController
    {
        EmployeesManager em = new EmployeesManager();

        [Route("UploadFile")]// POST: api/Upload
        public HttpResponseMessage Post([FromBody]FileUploadData request)
        {
            if(!request.Verify())
            {
                var message = string.Format("File forma is not allowed");
                HttpError err = new HttpError(message);
                return Request.CreateResponse(HttpStatusCode.NotAcceptable, err);
            }

            var detail=em.SaveFile(request.GetFileBytes());
            return Request.CreateResponse(HttpStatusCode.OK,detail);
        }

        [Route("GenerateData")]// POST: api/Upload
        public HttpResponseMessage Post([FromBody]ExcelFile f)
        {
            em.GenerateData(f);

            return Request.CreateResponse(HttpStatusCode.OK);
        }

    }
}
