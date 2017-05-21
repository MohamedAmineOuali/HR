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
    public class TypeContratsController : ApiController
    {
        private HumanResourcesEntities db = new HumanResourcesEntities();

        // GET: api/TypeContrats
        public IQueryable<TypeContrat> GetTypeContrats()
        {
            return db.TypeContrats;
        }

        // GET: api/TypeContrats/5
        [ResponseType(typeof(TypeContrat))]
        public IHttpActionResult GetTypeContrat(int id)
        {
            TypeContrat typeContrat = db.TypeContrats.Find(id);
            if (typeContrat == null)
            {
                return NotFound();
            }

            return Ok(typeContrat);
        }

        // PUT: api/TypeContrats/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTypeContrat(int id, TypeContrat typeContrat)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != typeContrat.Id)
            {
                return BadRequest();
            }

            db.Entry(typeContrat).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TypeContratExists(id))
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

        // POST: api/TypeContrats
        [ResponseType(typeof(TypeContrat))]
        public IHttpActionResult PostTypeContrat(TypeContrat typeContrat)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.TypeContrats.Add(typeContrat);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = typeContrat.Id }, typeContrat);
        }

        // DELETE: api/TypeContrats/5
        [ResponseType(typeof(TypeContrat))]
        public IHttpActionResult DeleteTypeContrat(int id)
        {
            TypeContrat typeContrat = db.TypeContrats.Find(id);
            if (typeContrat == null)
            {
                return NotFound();
            }

            db.TypeContrats.Remove(typeContrat);
            db.SaveChanges();

            return Ok(typeContrat);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TypeContratExists(int id)
        {
            return db.TypeContrats.Count(e => e.Id == id) > 0;
        }
    }
}