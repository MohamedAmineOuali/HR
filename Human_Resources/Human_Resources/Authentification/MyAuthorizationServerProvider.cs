using Human_Resources.Metier.Model;
using Human_Resources.Metier.Traitement;
using Microsoft.Owin.Security.OAuth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
namespace Human_Resources
{
    public class MyAuthorizationServerProvider : OAuthAuthorizationServerProvider
    {
        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            context.Validated(); // 
        }

        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            Compte compte = Authentification.GetAccess(context.UserName, context.Password);
            var identity = new ClaimsIdentity(context.Options.AuthenticationType);

            if(compte==null)
            {
                context.SetError("invalid_grant", "Provided username and password is incorrect");
                return;
            }
            else
            {
                 identity.AddClaim(new Claim(ClaimTypes.Role, compte.Role.Libelle));

                 identity.AddClaim(new Claim(ClaimTypes.Sid, compte.Id.ToString()));

                 context.Validated(identity);
            }
        }

    }
}