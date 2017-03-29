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
    [RoutePrefix("api/Categories")]
    public class CategoriesController : ApiController
    {
        
        private HumanResourcesEntities db = new HumanResourcesEntities();

        // GET: api/Categories
        [Route("")]
        [HttpGet]
        public IQueryable<Categorie> GetCategories1()
        {
            return db.Categories1;
        }
        [Route("{lib:string}")]
        [HttpGet]
        [ResponseType(typeof(Categorie))]
        public IHttpActionResult GetCategorieByLibelle(string lib)
        {
            
            Categorie categorie = db.Categories1.Where(e => e.Libelle == lib).FirstOrDefault();
            if (categorie == null)
            {
                return NotFound();
            }

            return Ok(categorie);
        }

        

        // GET: api/Categories/5
        [Route("{id:int}")]
        [HttpGet]
        [ResponseType(typeof(Categorie))]
        public IHttpActionResult GetCategorie(int id)
        {
            Categorie categorie = db.Categories1.Find(id);
            if (categorie == null)
            {
                return NotFound();
            }

            return Ok(categorie);
        }

        // PUT: api/Categories/5
        // [Authorize(Roles = "admin")]
        [Route("{id:int}")]
        [HttpPut]
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCategorie(int id, Categorie categorie)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != categorie.Id)
            {
                return BadRequest();
            }

            db.Entry(categorie).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CategorieExists(id))
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

        // POST: api/Categories
        // [Authorize(Roles = "admin")]
        [Route("")]
        [HttpPost]
        [ResponseType(typeof(Categorie))]
        public IHttpActionResult PostCategorie(Categorie categorie)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Categories1.Add(categorie);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = categorie.Id }, categorie);
        }

        // DELETE: api/Categories/5
        // [Authorize(Roles = "admin")]
        [Route("{id:int}")]
        [HttpDelete]
        [ResponseType(typeof(Categorie))]
        public IHttpActionResult DeleteCategorie(int id)
        {
            Categorie categorie = db.Categories1.Find(id);
            if (categorie == null)
            {
                return NotFound();
            }

            db.Categories1.Remove(categorie);
            db.SaveChanges();

            return Ok(categorie);
        }
       

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CategorieExists(int id)
        {
            return db.Categories1.Count(e => e.Id == id) > 0;
        }
    }

   
}