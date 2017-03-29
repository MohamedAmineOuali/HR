using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;

namespace Human_Resources.Model
{
    public class UserCompte
    {
        public int Id { get; set; }
        public string Role { get; set; }

        public UserCompte(ClaimsIdentity identity)
        {
            Role = identity.Claims.Where(c => c.Type == ClaimTypes.Role)
                        .Select(c => c.Value).SingleOrDefault();
            Id = Convert.ToInt32(identity.Claims.Where(c => c.Type == ClaimTypes.Sid)
                        .Select(c => c.Value).SingleOrDefault());
        }
    }
}