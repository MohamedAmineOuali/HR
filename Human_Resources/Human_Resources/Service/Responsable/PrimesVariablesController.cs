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
    public class PrimesVariablesController : ApiController
    {
        private HumanResourcesEntities db = new HumanResourcesEntities();

        // GET: api/PrimesVariables
        public IQueryable<PrimesVariable> GetPrimesVariables()
        {
            return db.PrimesVariables;
        }

        // GET: api/PrimesVariables/5
        [ResponseType(typeof(PrimesVariable))]
        public IHttpActionResult GetPrimesVariable(int id)
        {
            PrimesVariable primesVariable = db.PrimesVariables.Find(id);
            if (primesVariable == null)
            {
                return NotFound();
            }

            return Ok(primesVariable);
        }

        // PUT: api/PrimesVariables/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPrimesVariable(int id, PrimesVariable primesVariable)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != primesVariable.Id)
            {
                return BadRequest();
            }

            db.Entry(primesVariable).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PrimesVariableExists(id))
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

        // POST: api/PrimesVariables
        [ResponseType(typeof(PrimesVariable))]
        public IHttpActionResult PostPrimesVariable(PrimesVariable primesVariable)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.PrimesVariables.Add(primesVariable);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (PrimesVariableExists(primesVariable.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = primesVariable.Id }, primesVariable);
        }
        //affecter prime a un emplye
        [HttpPut] 
        [Route("api/PrimesVariables/AffectPrime/{idPrime}/{idEmp}")]
        public IHttpActionResult AffectPrime(int idPrime, int idEmp)
        {
            var prime = db.PrimesVariables.Find(idPrime);
            if (prime == null)
                return NotFound(); 
            else
            {
                prime.FK_Employe = idEmp;
                db.Entry(prime).State = EntityState.Modified;
                try
                {
                    db.SaveChanges(); 

                }
                catch (Exception  )
                {
                    return StatusCode(HttpStatusCode.NotModified);  
                    
                }
                return StatusCode(HttpStatusCode.OK); ; 

            }
        }
        // DELETE: api/PrimesVariables/5
        [ResponseType(typeof(PrimesVariable))]
        public IHttpActionResult DeletePrimesVariable(int id)
        {
            PrimesVariable primesVariable = db.PrimesVariables.Find(id);
            if (primesVariable == null)
            {
                return NotFound();
            }

            db.PrimesVariables.Remove(primesVariable);
            db.SaveChanges();

            return Ok(primesVariable);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PrimesVariableExists(int id)
        {
            return db.PrimesVariables.Count(e => e.Id == id) > 0;
        }
    }
}