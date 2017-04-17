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


        [Route("Add")]
        [HttpPost]
        public IHttpActionResult Add(InfosBanque ib)
        {
            var bank=db.InfosBanques.Add(ib);
            db.SaveChanges();
            return Ok(bank.Id);
        }


        [Route("GetByCIN/{cin:int}")]
        [HttpGet]
        public IHttpActionResult GetInfosBanqueByCIN(int cin)
        {
            Employe emp = db.Employes.Where(e => e.CIN == cin).FirstOrDefault();
            var ib = from i in db.InfosBanques
                             where (i.Id == emp.FK_InfosBanque)
                             select i;
            db.SaveChanges();

            return Ok(ib);
        }

        [Route("GetByMat/{mat:int}")]
        [HttpGet]
        public IHttpActionResult GetInfosBanqueByMat(int mat)
        {
            Employe emp = db.Employes.Where(e => e.Matricule == mat).FirstOrDefault();
            var ib = from i in db.InfosBanques
                     where (i.Id == emp.FK_InfosBanque)
                     select i;
            db.SaveChanges();

            return Ok(ib);
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

        [Route("Update")]
        [HttpPost]
        public IHttpActionResult UpdateInfosBanque(InfosBanque ib)
        {
            var ibq = (from i in db.InfosBanques
                      where i.Id == ib.Id
                      select i).FirstOrDefault();
            if (ib == null || ibq == null)
                return BadRequest();
            ibq.TelBanque = ib.TelBanque;
            ibq.ReglementPar = ib.ReglementPar;
            ibq.IBAN = ib.IBAN;
            ibq.NumeroCompte = ib.NumeroCompte;
            ibq.CleRIB = ib.CleRIB;
            ibq.CodeBanque = ib.CodeBanque;
            ibq.Domiciliation = ib.Domiciliation;
            ibq.CodeGuichet = ib.CodeGuichet;
            
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