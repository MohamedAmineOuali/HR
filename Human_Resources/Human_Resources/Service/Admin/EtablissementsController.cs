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
using Human_Resources.Metier;
using Human_Resources.Model;
using System.Security.Claims;

namespace Human_Resources.Service.Admin
{
    [RoutePrefix("api/Etablissements")]
    public class EtablissementsController : ApiController
    {
        private HumanResourcesEntities db = new HumanResourcesEntities();

        // GET: api/Etablissements
        //[Authorize(Roles = "admin")]
        [Route("")]
        public IQueryable<Etablissement> GetEtablissements()
        {
            return db.Etablissements;
        }

        // GET: api/Etablissements/5
        //[Authorize]
        [Route("{id:int}")]
        [HttpGet]
        [ResponseType(typeof(Etablissement))]
        public HttpResponseMessage GetEtablissement(int id)
        {
            var curUser = new UserCompte((ClaimsIdentity)User.Identity);

            Etablissement etablissement = db.Etablissements.Find(id);
            if (etablissement == null)
            {
                var message = string.Format("l'etablissement {0}, NOT FOUND", id);
                HttpError err = new HttpError(message);
                return Request.CreateResponse(HttpStatusCode.NotFound, err);
                
            }
            else if (curUser.Role != "admin" )
            {
                int curEtablissement = db.Comptes.Find(curUser.Id).Employe.Departement.Etablissement.Id;
                if(curEtablissement!=id)
                {
                    var message = string.Format("you don't have permission to access this établissement", id);
                    HttpError err = new HttpError(message);
                    return Request.CreateResponse(HttpStatusCode.Unauthorized, err);
                }
                
            }

            return Request.CreateResponse(HttpStatusCode.OK, etablissement);
        }

        // POST: api/Etablissements
        [ResponseType(typeof(Etablissement))]
        //[Authorize(Roles = "admin")]
        [Route("")]
        [HttpPost]
        public IHttpActionResult PostEtablissement(Etablissement etablissement)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Etablissements.Add(etablissement);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (EtablissementExists(etablissement.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = etablissement.Id }, etablissement);
        }

        // PUT: api/Etablissements/5
        //[Authorize(Roles = "admin")]
        [Route("")]
        [HttpPut]
        [ResponseType(typeof(void))]
        public IHttpActionResult PutEtablissement(int id, Etablissement etablissement)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != etablissement.Id)
            {
                return BadRequest();
            }

            db.Entry(etablissement).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EtablissementExists(id))
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

        // DELETE: api/Etablissements/5
        //[Authorize(Roles = "admin")]
        [Route("{id:int}")]
        [HttpDelete]
        [ResponseType(typeof(Etablissement))]
        public IHttpActionResult DeleteEtablissement(int id)
        {
            Etablissement etablissement = db.Etablissements.Find(id);
            if (etablissement == null)
            {
                return NotFound();
            }

            db.Etablissements.Remove(etablissement);
            db.SaveChanges();

            return Ok(etablissement);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool EtablissementExists(int id)
        {
            return db.Etablissements.Count(e => e.Id == id) > 0;
        }
    }
}