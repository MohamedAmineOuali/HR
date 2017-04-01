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
    [RoutePrefix("api/IGRs")]
    public class IGRsController : ApiController
    {
       
        private HumanResourcesEntities db = new HumanResourcesEntities();

        // GET: api/IGRs
        [Route("")]
        [HttpGet]
        public IQueryable<IGR> GetIGRs()
        {
            return db.IGRs;
        }

        // GET: api/IGRs/5
        [Route("{id:int}")]
        [HttpGet]
        [ResponseType(typeof(IGR))]
        public IHttpActionResult GetIGR(int id)
        {
            IGR iGR = db.IGRs.Find(id);
            if (iGR == null)
            {
                return NotFound();
            }

            return Ok(iGR);
        }

        // PUT: api/IGRs/5
        [Route("{id:int}")]
        [HttpPut]
        [ResponseType(typeof(void))]
        public IHttpActionResult PutIGR(int id, IGR iGR)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != iGR.Id)
            {
                return BadRequest();
            }

            db.Entry(iGR).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!IGRExists(id))
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

        // POST: api/IGRs
        [Route("")]
        [HttpPost]
        [ResponseType(typeof(IGR))]
        public IHttpActionResult PostIGR(IGR iGR)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.IGRs.Add(iGR);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = iGR.Id }, iGR);
        }

        // DELETE: api/IGRs/5
        [Route("{id:int}")]
        [HttpDelete]
        [ResponseType(typeof(IGR))]
        public IHttpActionResult DeleteIGR(int id)
        {
            IGR iGR = db.IGRs.Find(id);
            if (iGR == null)
            {
                return NotFound();
            }

            db.IGRs.Remove(iGR);
            db.SaveChanges();

            return Ok(iGR);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool IGRExists(int id)
        {
            return db.IGRs.Count(e => e.Id == id) > 0;
        }
    }
}