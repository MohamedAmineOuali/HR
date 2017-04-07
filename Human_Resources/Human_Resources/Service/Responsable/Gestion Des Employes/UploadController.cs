using Human_Resources.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Http;

namespace Human_Resources.Service.Responsable.Gestion_Des_Employes
{
    [RoutePrefix("api/Employee")]
    public class UploadController : ApiController
    {
        [Route("UploadFile")]// POST: api/Upload
        public void Post([FromBody]FileUploadData request)
        {
            string fileName = System.Web.Hosting.HostingEnvironment.MapPath(@"~/UploadedFile/employee/" + DateTime.Now.ToString("yyyyMMddTHHmmss")+ ".xlsx");
            string incoming = request.Base64Data.Replace('_', '/').Replace('-', '+');
            switch (request.Base64Data.Length % 4)
            {
                case 2: incoming += "=="; break;
                case 3: incoming += "="; break;
            }
            byte[] filebytes = Convert.FromBase64String(incoming);
            FileStream fs = new FileStream(fileName,
                                           FileMode.CreateNew,
                                           FileAccess.ReadWrite,
                                           FileShare.None);
            fs.Write(filebytes, 0, filebytes.Length);
            fs.Close();
        }
    }
}
