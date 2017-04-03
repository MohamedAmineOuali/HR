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

namespace Human_Resources.Service.Admin
{
    public class PrimeFixesController : ApiController
    {
        private HumanResourcesEntities db = new HumanResourcesEntities();

        // GET: api/PrimeFixes
        public IQueryable<PrimeFix> GetPrimeFixes()
        {
            return db.PrimeFixes;
        }

        // GET: api/PrimeFixes/5
        [ResponseType(typeof(PrimeFix))]
        public IHttpActionResult GetPrimeFix(int id)
        {
            PrimeFix primeFix = db.PrimeFixes.Find(id);
            if (primeFix == null)
            {
                return NotFound();
            }

            return Ok(primeFix);
        }

        // PUT: api/PrimeFixes/5
        [Authorize(Roles = "admin")]
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPrimeFix(int id, PrimeFix primeFix)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != primeFix.Id)
            {
                return BadRequest();
            }

            db.Entry(primeFix).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PrimeFixExists(id))
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

        
        // POST: api/PrimeFixes
        // [Authorize(Roles = "admin")]
        [ResponseType(typeof(PrimeFix))]
        public IHttpActionResult PostPrimeFix(PrimeFix primeFix)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.PrimeFixes.Add(primeFix);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = primeFix.Id }, primeFix);
        }

        // DELETE: api/PrimeFixes/5
        [Authorize(Roles = "admin")]
        [ResponseType(typeof(PrimeFix))]
        public IHttpActionResult DeletePrimeFix(int id)
        {
            PrimeFix primeFix = db.PrimeFixes.Find(id);
            if (primeFix == null)
            {
                return NotFound();
            }

            db.PrimeFixes.Remove(primeFix);
            db.SaveChanges();

            return Ok(primeFix);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PrimeFixExists(int id)
        {
            return db.PrimeFixes.Count(e => e.Id == id) > 0;
        }
    }
}