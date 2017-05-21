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
using System.Security.Claims;
using Human_Resources.Model;
using System.Collections.Specialized;

namespace Human_Resources.Service.Admin
{

    [RoutePrefix("api/Comptes")]
    public class ComptesController : ApiController
    {
        private HumanResourcesEntities db = new HumanResourcesEntities();

        [Authorize(Roles = "admin")]
        [Route("")]
        public List<CompteDetail> GetComptes()
        {
            List<Compte> comptes = db.Comptes.Include("Employe").Include("Etablissement").ToList();

            List<CompteDetail> comptesDetails = comptes
                                        .Select(c => new CompteDetail()
                                        {
                                            Id = c.Id,
                                            Login = c.Login,
                                            Etablissement = c.Etablissement.Label,
                                            Role = c.Role.Libelle,
                                            Nom = c.Employe != null ? c.Employe.Nom + " " + c.Employe.Prenom : null
                                        }).ToList();

            return comptesDetails;

        }
        [Authorize(Roles = "admin")]
        [Route("responsable")]
        public List<Compte> GetComptesResponsable()
        {
            List<Compte> comptes = db.Comptes.Where(c => c.Role.Libelle == "responsable").Include("Employe").Include("Etablissement").ToList();

         

           return comptes;

        }
        // GET: api/Comptes/5
        [Authorize]
        [Route("{id:int}")]
        [HttpGet]
        [ResponseType(typeof(Compte))]
        public HttpResponseMessage GetCompte(int id)
        {
            var curUser=new UserCompte((ClaimsIdentity)User.Identity);

            Compte compte = db.Comptes.Find(id);
            if (compte == null)
            {
                var message = string.Format("the compte {0}, NOT FOUND", id);
                HttpError err = new HttpError(message);
                return Request.CreateResponse(HttpStatusCode.NotFound, err);
            }
            else if (curUser.Role != "admin" && compte.Id != curUser.Id)
            {
                var message = string.Format("you don't have permission to access this compte", id);
                HttpError err = new HttpError(message);
                return Request.CreateResponse(HttpStatusCode.Unauthorized, err);
            }
            else
                return Request.CreateResponse(HttpStatusCode.OK);
        }

        // POST: api/Comptes
        [Authorize(Roles = "admin")]
        [Route("")]
        [HttpPost]
        public HttpResponseMessage PostCompte([FromBody]dynamic request)
        {
            var role = (string)request["Role"];
            var etablissement = (int?)request["Etablissement"];
            var compte = new Compte { Login= request["Login"], Password= request["Password"] };
            compte.Role= (from r in db.Roles
                          where (r.Libelle == role)
                          select r
                          ).FirstOrDefault();
            compte.FK_Etablissement = etablissement;
            if (compte.Role==null || compte.FK_Etablissement==null)
            {
                HttpError err = new HttpError(string.Format("Se role n'existe pas"));
                return Request.CreateResponse(HttpStatusCode.Conflict, err);
            }
            db.Comptes.Add(compte);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (CompteExists(compte.Id))
                {
                    HttpError err = new HttpError(string.Format("Le compte existe déja"));
                    return Request.CreateResponse(HttpStatusCode.Conflict, err);
                }
                else
                {
                    HttpError msg = new HttpError(string.Format("Le compte ne peut pas etre crée voire fichier log"));
                    return Request.CreateResponse(HttpStatusCode.ExpectationFailed, msg);
                }
            }
            return Request.CreateResponse(HttpStatusCode.OK, compte);
        }


        // PUT: api/Comptes/5
        //[Authorize(Roles = "admin")]
        [Route("{id:int}")]
        [HttpPut]
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCompte(int id, Compte compte)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != compte.Id)
            {
                return BadRequest();
            }

            db.Entry(compte).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CompteExists(id))
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

        // DELETE: api/Comptes/5
        //[Authorize(Roles = "admin")]
        [Route("{id:int}")]
        [HttpDelete]
        [ResponseType(typeof(Compte))]
        public IHttpActionResult DeleteCompte(int id)
        {
            Compte compte = db.Comptes.Find(id);
            if (compte == null)
            {
                return NotFound();
            }

            db.Comptes.Remove(compte);
            db.SaveChanges();

            return Ok(compte);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CompteExists(int id)
        {
            return db.Comptes.Count(e => e.Id == id) > 0;
        }
    }
}