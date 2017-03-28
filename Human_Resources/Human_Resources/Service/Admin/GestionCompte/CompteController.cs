using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Human_Resources.Metier.Model;
using System.Security.Claims;

namespace Human_Resources.Service.Admin.GestionCompte
{
    [RoutePrefix("api/Compte")]
    public class CompteController : ApiController
    {
        [Authorize(Roles = "admin")]
        [Route("")]
        public IEnumerable<Compte> Get()
        {
            using (HumanResourcesEntities db = new HumanResourcesEntities())
            {
                return db.Comptes.ToList();
            }
        }

        // GET: api/Compte/5
        //[Authorize(Roles = "admin")]
        [Route("{id:int}")]
        [HttpGet]
        public Compte Get(int id)
        {
            using (HumanResourcesEntities db = new HumanResourcesEntities())
            {var a=db.Comptes.Where(p => p.Id == id).First() ;
                return a;
            }
        }

        //[Authorize(Roles = "admin")]
        // POST: api/Compte
        [Route("")]
        [HttpPost]
        public void Post(Compte c)
        {
            using (HumanResourcesEntities db = new HumanResourcesEntities())
            {
                 db.Comptes.Add(c);
                db.SaveChanges();
                return;
            }
        }

        //[Authorize(Roles = "admin")]
        // PUT: api/Compte/5
        [Route("{id:int}")]
        [HttpPut]
        public void Put(int id, [FromBody]Compte c)
        {
            using (HumanResourcesEntities db = new HumanResourcesEntities())
            {
                var compte = db.Comptes.SingleOrDefault(b => b.Id == id);
                if (compte != null)
                {
                    try
                    {
                        compte.Login = c.Login;
                        compte.Role = c.Role;
                        compte.Password = c.Password;
                        db.SaveChanges();
                    }
                    catch (Exception ex)
                    {
                        throw;
                    }
                }
            }

        }

        //[Authorize(Roles = "admin")]
        // DELETE: api/Compte/5
        [Route("{id:int}")]
        [HttpDelete]
        public void Delete(int id)
        {
            using (HumanResourcesEntities db = new HumanResourcesEntities())
            {
                try
                {
                    var compte = new Compte { Id = id };
                    db.Comptes.Attach(compte);
                    db.Comptes.Remove(compte);
                    db.SaveChanges();
                }
                catch (Exception ex)
                {
                    throw;
                }
            }
        }
    }
}
