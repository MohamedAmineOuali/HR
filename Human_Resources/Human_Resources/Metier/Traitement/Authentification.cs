using Human_Resources.Metier.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Human_Resources.Metier.Traitement
{
    public class Authentification
    {
        public static Compte GetAccess(string login, string password)
        {
            using (HumanResourcesEntities db = new HumanResourcesEntities())
            {
                Compte compte=db.Comptes.Include("Role").FirstOrDefault(u => u.Login == login
                     && u.Password == password);
                return compte;
            }

        }
    }
}