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

namespace Human_Resources.Service.Responsable.Gestion_Des_Employes
{
    [RoutePrefix("api/Contrat")]
    public class ContratsController : ApiController
    {
        private HumanResourcesEntities db = new HumanResourcesEntities();


        [Route("Add/{categorie}/{type}")]
        [HttpPost]
        public IHttpActionResult AddContract(Contrat contrat , string categorie , string type)
        {

            int fk_categ = (from c in db.Categories
                            where (c.Libelle == categorie)
                            select c.Id).FirstOrDefault();
            int fk_typeCtr = (from c in db.TypeContrats
                            where (c.Type == type)
                            select c.Id).FirstOrDefault();
            contrat.FK_Categorie = fk_categ;
            contrat.FK_TypeContrat = fk_typeCtr;

            db.Contrats.Add(contrat);
            db.SaveChanges();
            return Ok();
        }

        [Route("GetContratByID/{id:int}")]
        [HttpGet]
        public IHttpActionResult GetContratById(int id)
        {

            var contrat = (from c in db.Contrats
                            where (c.Id == id)
                            select c).FirstOrDefault();
            if(contrat==null)
                return NotFound();

            return Ok(contrat);
            
        }

        [Route("GetContratByMatricule/{mat:int}")]
        [HttpGet]
        public IHttpActionResult GetContratByMatricule(int mat)
        {

            var emp = (from c in db.Employes
                           where (c.Matricule == mat)
                           select c).FirstOrDefault();
            if (emp == null)
                  return NotFound();

            var contrat = (from c in db.Contrats
                           where (c.Id == emp.FK_Contrat)
                           select c).FirstOrDefault();
            return Ok(contrat);

        }




        // GET: api/Contrats
        public IQueryable<Contrat> GetContrats()
        {
            return db.Contrats;
        }

        // GET: api/Contrats/5
        [ResponseType(typeof(Contrat))]
        public IHttpActionResult GetContrat(int id)
        {
            Contrat contrat = db.Contrats.Find(id);
            if (contrat == null)
            {
                return NotFound();
            }

            return Ok(contrat);
        }

        // PUT: api/Contrats/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutContrat(int id, Contrat contrat)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != contrat.Id)
            {
                return BadRequest();
            }

            db.Entry(contrat).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ContratExists(id))
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

        // POST: api/Contrats
        [ResponseType(typeof(Contrat))]
        public IHttpActionResult PostContrat(Contrat contrat)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Contrats.Add(contrat);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = contrat.Id }, contrat);
        }

        // DELETE: api/Contrats/5
        [ResponseType(typeof(Contrat))]
        public IHttpActionResult DeleteContrat(int id)
        {
            Contrat contrat = db.Contrats.Find(id);
            if (contrat == null)
            {
                return NotFound();
            }

            db.Contrats.Remove(contrat);
            db.SaveChanges();

            return Ok(contrat);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ContratExists(int id)
        {
            return db.Contrats.Count(e => e.Id == id) > 0;
        }
    }
}