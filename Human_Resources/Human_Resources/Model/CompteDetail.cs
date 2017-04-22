using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Human_Resources.Model
{
   

    public class CompteDetail
    {
        public int Id { get; set; }
        public String Login { get; set; }
        public String Nom { get; set; }
        public String Etablissement { get; set; }
        public String Role { get; set; }

    }
}