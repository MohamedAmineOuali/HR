using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using Human_Resources.Metier.Model;

namespace Human_Resources.Service.Admin.Gestion_des_formules
{
    [RoutePrefix("api/CNRPs")]
    public class CNRPsController : ApiController
    {
        private HumanResourcesEntities db = new HumanResourcesEntities();

        // GET: api/CNRPs

        [Route("")]
        [HttpGet]
        public IQueryable<CNRP> GetCNRPS()
        {
            return db.CNRPS;
        }

        // GET: api/CNRPs/5
        [Route("{id:int}")]
        [HttpGet]
        [ResponseType(typeof(CNRP))]
        public IHttpActionResult GetCNRP(int id)
        {
            CNRP cNRP = db.CNRPS.Find(id);
            if (cNRP == null)
            {
                return NotFound();
            }

            return Ok(cNRP);
        }

        // PUT: api/CNRPs/5
        [Route("{id:int}")]
        [HttpPut]
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCNRP(int id, CNRP cNRP)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != cNRP.Id)
            {
                return BadRequest();
            }

            db.Entry(cNRP).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CNRPExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/CNRPs
        [Route("")]
        [HttpPost]
        [ResponseType(typeof(CNRP))]
        public IHttpActionResult PostCNRP(CNRP cNRP)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.CNRPS.Add(cNRP);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = cNRP.Id }, cNRP);
        }

        // DELETE: api/CNRPs/5
        [Route("{id:int}")]
        [HttpDelete]
        [ResponseType(typeof(CNRP))]
        public IHttpActionResult DeleteCNRP(int id)
        {
            CNRP cNRP = db.CNRPS.Find(id);
            if (cNRP == null)
            {
                return NotFound();
            }

            db.CNRPS.Remove(cNRP);
            db.SaveChanges();

            return Ok(cNRP);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CNRPExists(int id)
        {
            return db.CNRPS.Count(e => e.Id == id) > 0;
        }
    }
}