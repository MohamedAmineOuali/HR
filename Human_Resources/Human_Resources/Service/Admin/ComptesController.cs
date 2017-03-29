﻿using System;
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
namespace Human_Resources.Service.Admin
{
    [RoutePrefix("api/Comptes")]
    public class ComptesController : ApiController
    {
        private HumanResourcesEntities db = new HumanResourcesEntities();

        // GET: api/Comptes
        //[Authorize(Roles = "admin")]
        [Route("")]
        public IQueryable<Compte> GetComptes()
        {
            return db.Comptes;
        }

        // GET: api/Comptes/5
        //[Authorize]
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
                return Request.CreateResponse(HttpStatusCode.OK, compte);
        }

        // POST: api/Comptes
        //[Authorize(Roles = "admin")]
        [Route("")]
        [HttpPost]
        [ResponseType(typeof(Compte))]
        public HttpResponseMessage PostCompte(Compte compte)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ModelState);
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
                    return Request.CreateResponse(HttpStatusCode.Unauthorized, err);
                }
                else
                {
                    HttpError msg = new HttpError(string.Format("Le compte ne peut pas eter crée voire fichier log"));
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