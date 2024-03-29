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
using Human_Resources.Model;
using System.Security.Claims;

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
        public List<Departement> GetDepartements()
        {
            var curUser = new UserCompte((ClaimsIdentity)User.Identity);
            List<Departement> dep;

            if (curUser.Role == "admin")
                dep=db.Departements.Include("Etablissement").Include("Employe").Include("Employes").ToList();
            else
            {
                var e = (from c in db.Comptes where c.Id == curUser.Id select c.Etablissement.Id).FirstOrDefault();
                dep= db.Departements.Where(d => d.FK_Etablissement == e).Include("Etablissement").Include("Employe").Include("Employes").ToList();
            }

            foreach(Departement e in dep)
            {
                e.Employe = null;
                e.Employes = null;
                e.Etablissement = null;
            }

            return dep;

        }

        [Route("empbydep")]
        public List<EmpByDep> GetEmpByDep()
        {
            var curUser = new UserCompte((ClaimsIdentity)User.Identity);
            var e = (from c in db.Comptes where c.Id == curUser.Id select c.Etablissement.Id).FirstOrDefault();

            var list = from r in db.Employes
                       where r.Departement.FK_Etablissement ==e
                       group r by r.Departement.Libelle into g
                       select new EmpByDep { dep = g.Key, nbEmp = g.Count() };

            return list.ToList<EmpByDep>();
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