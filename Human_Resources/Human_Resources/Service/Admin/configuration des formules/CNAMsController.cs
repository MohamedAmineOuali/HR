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
     [RoutePrefix("api/CNAMs")]
    public class CNAMsController : ApiController
    {
       
        private HumanResourcesEntities db = new HumanResourcesEntities();

        // GET: api/CNAMs
        [Route("")]
        [HttpGet]
        public IQueryable<CNAM> GetCNAMs()
        {
            return db.CNAMs;
        }

        // GET: api/CNAMs/5
        [Route("{id:int}")]
        [HttpGet]
        [ResponseType(typeof(CNAM))]
        public IHttpActionResult GetCNAM(int id)
        {
            CNAM cNAM = db.CNAMs.Find(id);
            if (cNAM == null)
            {
                return NotFound();
            }

            return Ok(cNAM);
        }

        // PUT: api/CNAMs/5
        [Route("{id:int}")]
        [HttpPut]
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCNAM(int id, CNAM cNAM)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != cNAM.Id)
            {
                return BadRequest();
            }

            db.Entry(cNAM).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CNAMExists(id))
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

        // POST: api/CNAMs
        [Route("")]
        [HttpPost]
        [ResponseType(typeof(CNAM))]
        public IHttpActionResult PostCNAM(CNAM cNAM)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.CNAMs.Add(cNAM);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = cNAM.Id }, cNAM);
        }

        // DELETE: api/CNAMs/5
        [Route("{id:int}")]
        [HttpDelete]
        [ResponseType(typeof(CNAM))]
        public IHttpActionResult DeleteCNAM(int id)
        {
            CNAM cNAM = db.CNAMs.Find(id);
            if (cNAM == null)
            {
                return NotFound();
            }

            db.CNAMs.Remove(cNAM);
            db.SaveChanges();

            return Ok(cNAM);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CNAMExists(int id)
        {
            return db.CNAMs.Count(e => e.Id == id) > 0;
        }
    }
}