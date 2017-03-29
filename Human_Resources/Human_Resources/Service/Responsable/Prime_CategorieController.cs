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
    public class Prime_CategorieController : ApiController
    {
        private HumanResourcesEntities db = new HumanResourcesEntities();

        // GET: api/Prime_Categorie
        public IQueryable<Prime_Categorie> GetPrime_Categorie()
        {
            return db.Prime_Categorie;
        }
        //GET : liste de prime par category 
        [HttpGet] 
        [Route("api/Prime_Categorie/ByCategory/{idCat}")]
        public IHttpActionResult GetPrimeByCategory(int idCat)
        {
            var result = db.Prime_Categorie.Where(e => e.FK_Categorie == idCat).Select(e=>e.Categorie).ToList<Categorie>();
            if (result.Count == 0)
                return NotFound();
            else
                return Ok(result); 

        }
        //Get All prime fixe by Category: 
        [HttpGet]
        [Route("api/Prime_Categorie/ByCategory")]
        public IHttpActionResult GetPrimeByCategory()
        {
            var result = (from p in db.Prime_Categorie
                         group p by p.Categorie into g
                         select new { cat = g.Key, primes = g }).ToList();
            if (result.Count == 0)
                return NotFound();
            else
                return Ok(result); 

        }
        //recuperer les category qui ont prime x : 
        [HttpGet] 
        [ Route()]
        public IHttpActionResult GetCategoryByPrime(int prime)
        {
            var result = db.Prime_Categorie.Where(e => e.FK_PrimeFixe == prime).Select(e => e.Categorie).ToList();
            if (result.Count == 00)
                return NotFound();
            else
                return Ok(result); 

        }
        // GET: api/Prime_Categorie/5
        [ResponseType(typeof(Prime_Categorie))]
        public IHttpActionResult GetPrime_Categorie(int id)
        {
            Prime_Categorie prime_Categorie = db.Prime_Categorie.Find(id);
            if (prime_Categorie == null)
            {
                return NotFound();
            }

            return Ok(prime_Categorie);
        }

        // PUT: api/Prime_Categorie/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPrime_Categorie(int id, Prime_Categorie prime_Categorie)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != prime_Categorie.Id)
            {
                return BadRequest();
            }

            db.Entry(prime_Categorie).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Prime_CategorieExists(id))
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
        //affecter les prime fixe a une category 
        // POST: api/Prime_Categorie
        [ResponseType(typeof(Prime_Categorie))]
        public IHttpActionResult PostPrime_Categorie(Prime_Categorie prime_Categorie)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Prime_Categorie.Add(prime_Categorie);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (Prime_CategorieExists(prime_Categorie.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = prime_Categorie.Id }, prime_Categorie);
        }

        // DELETE: api/Prime_Categorie/5
        [ResponseType(typeof(Prime_Categorie))]
        public IHttpActionResult DeletePrime_Categorie(int id)
        {
            Prime_Categorie prime_Categorie = db.Prime_Categorie.Find(id);
            if (prime_Categorie == null)
            {
                return NotFound();
            }

            db.Prime_Categorie.Remove(prime_Categorie);
            db.SaveChanges();

            return Ok(prime_Categorie);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool Prime_CategorieExists(int id)
        {
            return db.Prime_Categorie.Count(e => e.Id == id) > 0;
        }
    }
}