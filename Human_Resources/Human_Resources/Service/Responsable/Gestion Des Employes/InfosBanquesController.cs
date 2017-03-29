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

namespace Human_Resources.Service.Responsable.Gestion_Des_Employes
{
    [RoutePrefix("api/InfosBanque")]
    public class InfosBanquesController : ApiController
    {
        private HumanResourcesEntities db = new HumanResourcesEntities();

        [Route("GetInfosBanqueByCIN/{cin:int}")]
        [HttpPost]
        public IHttpActionResult GetInfosBanqueByCIN(InfosBanque ib, int cin)
        {
            db.InfosBanques.Add(ib);
            Employe emp = db.Employes.Where(e => e.CIN == cin).FirstOrDefault();
            emp.InfosBanque = ib;
            db.SaveChanges();

            return Ok();
        }

        //Add InfosBanque to EmployeeByID
        [Route("AddByID/{id:int}")]
        [HttpPost]
        public IHttpActionResult AddInfosBanqueByID(InfosBanque ib, int id)
        {
            /*db.InfosBanques.Add(new InfosBanque {
                CleRIB=ib.CleRIB,
                CodeBanque=ib.CodeBanque,
                CodeGuichet=ib.CodeGuichet,
                Domiciliation=ib.Domiciliation,
                IBAN=ib.IBAN,
                NumeroCompte=ib.NumeroCompte,
                ReglementPar=ib.ReglementPar,
                TelBanque=ib.TelBanque
            });*/
            db.InfosBanques.Add(ib);
            Employe emp = db.Employes.Where(e => e.Id == id).FirstOrDefault();
            emp.InfosBanque = ib;
            db.SaveChanges();

            return Ok();
        }

        [Route("AddByCIN/{cin:int}")]
        [HttpPost]
        public IHttpActionResult AddInfosBanqueByCIN(InfosBanque ib, int cin)
        {
            db.InfosBanques.Add(ib);
            Employe emp = db.Employes.Where(e => e.CIN == cin).FirstOrDefault();
            emp.InfosBanque = ib;
            db.SaveChanges();

            return Ok();
        }

        [Route("AddByMat/{mat:int}")]
        [HttpPost]
        public IHttpActionResult AddInfosBanqueByMat(InfosBanque ib, int mat)
        {
            db.InfosBanques.Add(ib);
            Employe emp = db.Employes.Where(e => e.Matricule == mat).FirstOrDefault();
            emp.InfosBanque = ib;
            db.SaveChanges();

            return Ok();
        }




        // GET: api/InfosBanques
        public IQueryable<InfosBanque> GetInfosBanques()
        {
            return db.InfosBanques;
        }

        // GET: api/InfosBanques/5
        [ResponseType(typeof(InfosBanque))]
        public IHttpActionResult GetInfosBanque(int id)
        {
            InfosBanque infosBanque = db.InfosBanques.Find(id);
            if (infosBanque == null)
            {
                return NotFound();
            }

            return Ok(infosBanque);
        }

        // PUT: api/InfosBanques/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutInfosBanque(int id, InfosBanque infosBanque)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != infosBanque.Id)
            {
                return BadRequest();
            }

            db.Entry(infosBanque).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InfosBanqueExists(id))
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

        // POST: api/InfosBanques
        [ResponseType(typeof(InfosBanque))]
        public IHttpActionResult PostInfosBanque(InfosBanque infosBanque)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.InfosBanques.Add(infosBanque);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (InfosBanqueExists(infosBanque.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = infosBanque.Id }, infosBanque);
        }

        // DELETE: api/InfosBanques/5
        [ResponseType(typeof(InfosBanque))]
        public IHttpActionResult DeleteInfosBanque(int id)
        {
            InfosBanque infosBanque = db.InfosBanques.Find(id);
            if (infosBanque == null)
            {
                return NotFound();
            }

            db.InfosBanques.Remove(infosBanque);
            db.SaveChanges();

            return Ok(infosBanque);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool InfosBanqueExists(int id)
        {
            return db.InfosBanques.Count(e => e.Id == id) > 0;
        }
    }
}