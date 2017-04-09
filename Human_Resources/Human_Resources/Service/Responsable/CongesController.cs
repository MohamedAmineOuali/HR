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
    public class CongesController : ApiController
    {
        private HumanResourcesEntities db = new HumanResourcesEntities();

        // GET: api/Conges
        public List<Conge> GetConges()
        {
            var result = db.Conges.ToList<Conge>() ;
            return result; 
        }
        

        // GET: api/Conges/5
        [ResponseType(typeof(Conge))]
        public IHttpActionResult GetConge(int id)
        {
            Conge conge = db.Conges.Find(id);
            if (conge == null)
            {
                return NotFound();
            }

            return Ok(conge);
        }

        //Get list de Congé d un seul employé 
        [HttpGet]
        [Route("api/CongeByEmploye/{id}")]
        public IQueryable<Conge> GetCongeByEmploye(int id)
        {
            var list = db.Conges.Where(e => e.FK_Employe == id);
            return list; 



        }
        //Get list Congé par mois: 
        [HttpGet]
        [Route("api/CongeByMonth/{mois}")]
        public IQueryable<Conge> GetCongeByMonth(int mois )
        {
            var list = db.Conges.Where(e => e.DateDebut.Value.Month == mois);
            return list;





        }
        // PUT: api/Conges/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutConge(int id, Conge conge)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != conge.Id)
            {
                return BadRequest();
            }

            db.Entry(conge).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CongeExists(id))
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

        // POST: api/Conges
        [ResponseType(typeof(Conge))]
        public IHttpActionResult PostConge(Conge conge)
        {
            //conge.DateDemande = DateTime.Now;
            //conge.DateDebut = DateTime.Now;

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Conges.Add(conge);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (CongeExists(conge.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = conge.Id }, conge);
        }

        // DELETE: api/Conges/5
        [ResponseType(typeof(Conge))]
        public IHttpActionResult DeleteConge(int id)
        {
            Conge conge = db.Conges.Find(id);
            if (conge == null)
            {
                return NotFound();
            }

            db.Conges.Remove(conge);
            db.SaveChanges();

            return Ok(conge);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CongeExists(int id)
        {
            return db.Conges.Count(e => e.Id == id) > 0;
        }


    }
}