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

namespace Human_Resources.Service.Responsable
{
    public class TypeCongesController : ApiController
    {
        private HumanResourcesEntities db = new HumanResourcesEntities();

        // GET: api/TypeConges
        public IQueryable<TypeConge> GetTypeConges()
        {
            return db.TypeConges;
        }

        // GET: api/TypeConges/5
        [ResponseType(typeof(TypeConge))]
        public IHttpActionResult GetTypeConge(int id)
        {
            TypeConge typeConge = db.TypeConges.Find(id);
            if (typeConge == null)
            {
                return NotFound();
            }

            return Ok(typeConge);
        }

        // PUT: api/TypeConges/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTypeConge(int id, TypeConge typeConge)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != typeConge.Id)
            {
                return BadRequest();
            }

            db.Entry(typeConge).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TypeCongeExists(id))
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

        // POST: api/TypeConges
        [ResponseType(typeof(TypeConge))]
        public IHttpActionResult PostTypeConge(TypeConge typeConge)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.TypeConges.Add(typeConge);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = typeConge.Id }, typeConge);
        }

        // DELETE: api/TypeConges/5
        [ResponseType(typeof(TypeConge))]
        public IHttpActionResult DeleteTypeConge(int id)
        {
            TypeConge typeConge = db.TypeConges.Find(id);
            if (typeConge == null)
            {
                return NotFound();
            }

            db.TypeConges.Remove(typeConge);
            db.SaveChanges();

            return Ok(typeConge);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TypeCongeExists(int id)
        {
            return db.TypeConges.Count(e => e.Id == id) > 0;
        }
    }
}