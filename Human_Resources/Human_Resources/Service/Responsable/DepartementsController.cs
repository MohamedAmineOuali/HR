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
    [RoutePrefix("api/Departements")]
    public class DepartementsController : ApiController
    {
        private HumanResourcesEntities db = new HumanResourcesEntities();

        // GET: api/Departements
        // GET: api/CNAMs
        [Route("")]
        [HttpGet]
        public IQueryable<Departement> GetDepartements()
        {
            return db.Departements;
        }

        // GET: api/Departements/5
        [Route("{id:int}")]
        [HttpGet]
        [ResponseType(typeof(Departement))]
        public IHttpActionResult GetDepartement(int id)
        {
            Departement departement = db.Departements.Find(id);
            if (departement == null)
            {
                return NotFound();
            }

            return Ok(departement);
        }

        [HttpGet]
        [Route("GeDepartementByEtablissement/{id}")]
        public IQueryable<Departement> GeDepartementByEtablissement(int id)
        {
            var list = db.Departements.Where(e => e.FK_Etablissement == id);
            return list;



        }
        [Route("{name}")]
        [HttpGet]
        [ResponseType(typeof(Departement))]
        public IHttpActionResult GetDepartementByName(string name)
        {
            Departement departement = db.Departements.Where(e => e.Libelle == name).FirstOrDefault(); ;
            if (departement == null)
            {
                return NotFound();
            }

            return Ok(departement);
        }

        // PUT: api/Departements/5
        [Route("{id:int}")]
        [HttpPut]
        [ResponseType(typeof(void))]
        public IHttpActionResult PutDepartement(int id, Departement departement)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != departement.Id)
            {
                return BadRequest();
            }

            db.Entry(departement).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DepartementExists(id))
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

        // POST: api/Departements
        [Route("")]
        [HttpPost]
        [ResponseType(typeof(Departement))]
        public IHttpActionResult PostDepartement(Departement departement)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Departements.Add(departement);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = departement.Id }, departement);
        }

        // DELETE: api/Departements/5
        [Route("{id:int}")]
        [HttpDelete]
        [ResponseType(typeof(Departement))]
        public IHttpActionResult DeleteDepartement(int id)
        {
            Departement departement = db.Departements.Find(id);
            if (departement == null)
            {
                return NotFound();
            }

            db.Departements.Remove(departement);
            db.SaveChanges();

            return Ok(departement);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool DepartementExists(int id)
        {
            return db.Departements.Count(e => e.Id == id) > 0;
        }
    }
}