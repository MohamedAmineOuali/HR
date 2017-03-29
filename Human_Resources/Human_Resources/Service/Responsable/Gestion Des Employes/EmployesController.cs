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

namespace Human_Resources.Service.Responsable
{

    [RoutePrefix("api/Employee")]
    public class EmployesController : ApiController
    {
        private HumanResourcesEntities db = new HumanResourcesEntities();


        [Route("AddEmployee")]
        [HttpPost]
        public IHttpActionResult AddEmployee(Employe e)
        {
            db.Employes.Add(e);
            db.SaveChanges();
            return Ok();
        }

        //var result = db.Avances.Where(e => e.FK_Employe == emp).ToList<Avance>();
        [Route("DeleteEmployeeByID/{id:int}")]
        [ResponseType(typeof(Employe))]
        [HttpPost]
        public IHttpActionResult DeleteEmployeeByID(int id)
        {
            Employe employe = db.Employes.Find(id);
            if (employe == null)
            {
                return NotFound();
            }

            db.Employes.Remove(employe);
            db.SaveChanges();

            return Ok(employe);
        }

        [Route("DeleteEmployeeByMat/{mat:int}")]
        [HttpPost]
        public IHttpActionResult DeleteEmployeeByMatricule(int mat)
        {
            Employe employe = db.Employes.Where(e => e.Matricule == mat).FirstOrDefault();
            if (employe == null)
            {
                return NotFound();
            }

            db.Employes.Remove(employe);
            db.SaveChanges();

            return Ok(employe);
        }

        [Route("DeleteEmployeeByCIN/{cin:int}")]
        [HttpPost]
        public IHttpActionResult DeleteEmployeeByCIN(int cin)
        {
            Employe employe = db.Employes.Where(e => e.CIN == cin).FirstOrDefault();
            if (employe == null)
            {
                return NotFound();
            }

            db.Employes.Remove(employe);
            db.SaveChanges();

            return Ok(employe);
        }

        [Route("GetEmployeeByID/{id:int}")]
        [HttpPost]
        public IHttpActionResult GetEmployeeByID(int id)
        {
            Employe employe = db.Employes.Where(e => e.Id == id).FirstOrDefault();
            if (employe == null)
            {
                return NotFound();
            }

           return Ok(employe);
        }




        [Route("GetEmployeeByMat/{mat:int}")]
        [HttpPost]
        public IHttpActionResult GetEmployeeByMatricule(int mat)
        {
            Employe employe = db.Employes.Where(e => e.Matricule == mat).FirstOrDefault();
            if (employe == null)
            {
                return NotFound();
            }
            else
                return Ok(employe);
        }

        [Route("GetEmployeeByCIN/{cin:int}")]
        [HttpPost]
        public IHttpActionResult GetEmployeeByCIN(int cin)
        {
            Employe employe = db.Employes.Where(e => e.CIN == cin).FirstOrDefault();
            if (employe == null)
            {
                return NotFound();
            }
            else
                return Ok(employe);
        }

        [Route("UpdateEmployee")]
        [HttpPost]
        public IHttpActionResult UpdateEmployee(Employe e)
        {
            Employe employe = db.Employes.Where(emp => emp.Id == e.Id).FirstOrDefault();
            if (employe == null)
            {
                return BadRequest();
            }

            employe = e;
            db.SaveChanges();
            return Ok();
        }

        [Route("UpdateEmployeeByMat")]
        [HttpPost]
        public IHttpActionResult UpdateEmployeeByMat(Employe e)
        {
            Employe employe = db.Employes.Where(emp => emp.Matricule == e.Matricule).FirstOrDefault();
            if (employe == null)
            {
                return BadRequest();
            }

            employe = e;
            db.SaveChanges();
            return Ok();
        }

        [Route("UpdateEmployeeByCIN")]
        [HttpPost]
        public IHttpActionResult UpdateEmployeeByCIN(Employe e)
        {
            Employe employe = db.Employes.Where(emp => emp.CIN == e.CIN).FirstOrDefault();
            if (employe == null)
            {
                return BadRequest();
            }

            employe = e;
            db.SaveChanges();
            return Ok();
        }









        // GET: api/Employes
        public IQueryable<Employe> GetEmployes()
        {
            return db.Employes;
        }

        // GET: api/Employes/5
        [ResponseType(typeof(Employe))]
        public IHttpActionResult GetEmploye(int id)
        {
            Employe employe = db.Employes.Find(id);
            if (employe == null)
            {
                return NotFound();
            }

            return Ok(employe);
        }

        // PUT: api/Employes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutEmploye(int id, Employe employe)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != employe.Id)
            {
                return BadRequest();
            }

            db.Entry(employe).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmployeExists(id))
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

        // POST: api/Employes
        [ResponseType(typeof(Employe))]
        public IHttpActionResult PostEmploye(Employe employe)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Employes.Add(employe);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (EmployeExists(employe.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = employe.Id }, employe);
        }

        // DELETE: api/Employes/5
        [ResponseType(typeof(Employe))]
        public IHttpActionResult DeleteEmploye(int id)
        {
            Employe employe = db.Employes.Find(id);
            if (employe == null)
            {
                return NotFound();
            }

            db.Employes.Remove(employe);
            db.SaveChanges();

            return Ok(employe);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool EmployeExists(int id)
        {
            return db.Employes.Count(e => e.Id == id) > 0;
        }
    }
}