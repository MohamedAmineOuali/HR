using Human_Resources.Metier.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Human_Resources.Service.Admin.GestionCompte
{
    [RoutePrefix("api/Compte")]
    public class CompteController : ApiController
    {


        // GET: api/Compte
        [Route("")]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Compte/5
        [Route("{id:int}")]
        [HttpGet]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Compte
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Compte/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Compte/5
        public void Delete(int id)
        {
        }
    }
}
