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
    public class AvancesController : ApiController
    {
        private HumanResourcesEntities db = new HumanResourcesEntities();

        // GET: api/Avances
        public List<Avance> GetAvances()
        {
            return db.Avances.ToList<Avance>();
        }

        // GET: api/Avances/5
        [ResponseType(typeof(Avance))]
        public IHttpActionResult GetAvance(int id)
        {
            Avance avance = db.Avances.Find(id);
            if (avance == null)
            {
                return NotFound();
            }

            return Ok(avance);
        }
        //Avance By Employe : 
        [HttpGet]
        [Route("api/Avances/AvanceByEmploye/{emp}")]
        public IHttpActionResult GetAvanceByEmploye(int emp)
        {
            var result = db.Avances.Where(e => e.FK_Employe == emp).ToList<Avance>();
            if (result.Count == 0)
            {
                return NotFound();
            }
            else
                return Ok(result);

        }
        //Avance By Mois/year
        [HttpGet]
        [Route("api/Avances/AvanceByMonth/{month}/{year}")]
        public IHttpActionResult GetAvanceByDate(int month,int year)
        {
            var result = db.Avances.Where(e => e.Mois.Value.Month == month &&e.Mois.Value.Year == year).ToList<Avance>();
            if (result.Count == 0)
                return NotFound();
            else
                return Ok(result); 



        }

        // PUT: api/Avances/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutAvance(int id, Avance avance)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != avance.Id)
            {
                return BadRequest();
            }

            db.Entry(avance).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AvanceExists(id))
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

        // POST: api/Avances
        [ResponseType(typeof(Avance))]
        public IHttpActionResult PostAvance(Avance avance)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            avance.DateVersement = DateTime.Now;
            avance.Mois = DateTime.Now; 

            db.Avances.Add(avance);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (AvanceExists(avance.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = avance.Id }, avance);
        }

        // DELETE: api/Avances/5
        [ResponseType(typeof(Avance))]
        public IHttpActionResult DeleteAvance(int id)
        {
            Avance avance = db.Avances.Find(id);
            if (avance == null)
            {
                return NotFound();
            }

            db.Avances.Remove(avance);
            db.SaveChanges();

            return Ok(avance);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AvanceExists(int id)
        {
            return db.Avances.Count(e => e.Id == id) > 0;
        }
    }
}