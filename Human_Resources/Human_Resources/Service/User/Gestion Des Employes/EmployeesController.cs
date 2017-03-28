using Human_Resources.Metier.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Human_Resources.Service.User.Gestion_Des_Employes
{
    [RoutePrefix("api/Employee")]
    public class EmployeesController : ApiController
    {
        // GET: api/Employee/AddEmployee
        [Route("AddEmployee")]
        [HttpPost]
        public void AddEmployee()
        {
            HumanResourcesEntities hre = new HumanResourcesEntities();
            hre.Employes.Add(new Metier.Model.Employe {
                Addresse = "Tunis",
                CIN = 07211359,
                DateDeNaissance = new DateTime(2017, 3, 3),
                Etat="Celibataire",
                Genre="Male",
                Nom="Oussama",
                Prenom="Ben Sghaier",
                Telephone=97000000,
                Natonalite="Tunisienne"
                });
            hre.SaveChanges();
        }

        // GET api/<controller>
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}