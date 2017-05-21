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
using Human_Resources.Service.Responsable.Gestion_Des_Employes;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Security.Claims;
using Human_Resources.Model;

namespace Human_Resources.Service.Responsable
{

    [RoutePrefix("api/Employee")]
    public class EmployesController : ApiController
    {
        private HumanResourcesEntities db = new HumanResourcesEntities();

        [Route("config")]
        [HttpPost]
        public IHttpActionResult Config(EmployeeConfig e)
        {
            string path = System.Web.Hosting.HostingEnvironment.MapPath(@"~/UploadedFile/employee/configEmp.json");

            string s = "{\"Adresse\":" + e.Adresse.ToString().ToLower() + ",\"CIN\":" + e.CIN.ToString().ToLower() + ",\"DateNaissance\":" + e.DateNaissance.ToString().ToLower()
                + ",\"Genre\":" + e.Genre.ToString().ToLower() + ",\"Grade\":" + e.Grade.ToString().ToLower() + ",\"LieuNaissance\":" + e.LieuNaissance.ToString().ToLower() + ",\"Matricule\":"
                + e.Matricule.ToString().ToLower() + ",\"NSS\": " + e.NSS.ToString().ToLower() + ",\"Nationalite\":" + e.Nationalite.ToString().ToLower() + ",\"Nom\":" + e.Nom.ToString().ToLower() + ",\"NombreEnfants\":"
                + e.NombreEnfants.ToString().ToLower() + ",\"Prenom\":" + e.Prenom.ToString().ToLower() + ",\"StatutSocial\":" + e.StatutSocial.ToString().ToLower() + ",\"Telephone\":" + e.Telephone.ToString().ToLower() + "}";



            //var d = Directory.GetCurrentDirectory();
            File.WriteAllText(path, s);
            /*bool b = File.Exists(@"/configEmp.json");
             b = File.Exists(@"./configEmp.txt");*/

            return Ok();
        }


        [Route("GetConfig")]
        [HttpGet]
        public IHttpActionResult GetConfig()
        {
            string path = System.Web.Hosting.HostingEnvironment.MapPath(@"~/UploadedFile/employee/configEmp.json" );
            if (File.Exists(path))
            {
                DataContractJsonSerializer serializer =
        new DataContractJsonSerializer(typeof(EmployeeConfig));

                var stream = File.Open(path, FileMode.Open);
                var yourObject = (EmployeeConfig)serializer.ReadObject(stream);
                stream.Close();

                return Ok(yourObject);
            }
            else
                return NotFound(); 
        }


        [Route("AddEmployee/{departement}")]
        [HttpPost]
        public IHttpActionResult AddEmployee(Employe e , string departement)
        {

            //Departement Foreign Key
            int? fk_dep = (from d in db.Departements
                          where (d.Libelle == departement)
                          select d.Id).FirstOrDefault();

            e.FK_Departement = fk_dep;
            
            db.Employes.Add(e);
            db.SaveChanges();
            return Ok();
        }
     //   [Authorize]
        [Route("GetAll")]
        [HttpGet]
        public IHttpActionResult GetAllEmployees()

        {
            var emp = db.Employes.ToList();
            
            return Ok(emp);
        }


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
        [HttpGet]
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



        [Authorize]
        [Route("AssociateEmployee/{departement}")]
        [HttpPost]
        public HttpResponseMessage AssociateEmployeeToCompte(Employe e,string departement)
        {
            var curUser = new UserCompte((ClaimsIdentity)User.Identity);

            Compte compte = db.Comptes.Find(curUser.Id);

            if(compte.Employe!=null)
            {
                var message = string.Format("Un employee est deja associer à ce compte");
                HttpError err = new HttpError(message);
                return Request.CreateResponse(HttpStatusCode.Conflict, err);
            }

            //Departement Foreign Key
            int? fk_dep = (from d in db.Departements
                           where (d.Libelle == departement)
                           select d.Id).FirstOrDefault();

            e.FK_Departement = fk_dep;
            db.Employes.Add(e);

            compte.Employe = e;

            db.Entry(compte).State = EntityState.Modified;
            db.SaveChanges();

            var data= new Dictionary<string, string>
                    {
                        {  "nom", compte.Employe.Nom},
                        { "prenom", compte.Employe.Prenom },
                        { "role", compte.Role.Libelle},
                         { "login", compte.Login}
                    };

            return Request.CreateResponse(HttpStatusCode.OK, data);
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