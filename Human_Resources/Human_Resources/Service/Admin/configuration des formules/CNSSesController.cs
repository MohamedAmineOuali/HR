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
    [RoutePrefix("api/CNSSes")]
    public class CNSSesController : ApiController
    {
      
        private HumanResourcesEntities db = new HumanResourcesEntities();

        // GET: api/CNSSes
        [Route("")]
        [HttpGet]
        public IQueryable<CNSS> GetCNSSes()
        {
            return db.CNSSes;
        }

        // GET: api/CNSSes/5
        [Route("{id:int}")]
        [HttpGet]
        [ResponseType(typeof(CNSS))]
        public IHttpActionResult GetCNSS(int id)
        {
            CNSS cNSS = db.CNSSes.Find(id);
            if (cNSS == null)
            {
                return NotFound();
            }

            return Ok(cNSS);
        }

        // PUT: api/CNSSes/5
        [Route("{id:int}")]
        [HttpPut]
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCNSS(int id, CNSS cNSS)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != cNSS.Id)
            {
                return BadRequest();
            }

            db.Entry(cNSS).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CNSSExists(id))
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

        // POST: api/CNSSes
        [Route("")]
        [HttpPost]
        [ResponseType(typeof(CNSS))]
        public IHttpActionResult PostCNSS(CNSS cNSS)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.CNSSes.Add(cNSS);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = cNSS.Id }, cNSS);
        }

        // DELETE: api/CNSSes/5
        [Route("{id:int}")]
        [HttpDelete]
        [ResponseType(typeof(CNSS))]
        public IHttpActionResult DeleteCNSS(int id)
        {
            CNSS cNSS = db.CNSSes.Find(id);
            if (cNSS == null)
            {
                return NotFound();
            }

            db.CNSSes.Remove(cNSS);
            db.SaveChanges();

            return Ok(cNSS);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CNSSExists(int id)
        {
            return db.CNSSes.Count(e => e.Id == id) > 0;
        }
    }
}