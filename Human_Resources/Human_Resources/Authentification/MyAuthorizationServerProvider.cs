using Human_Resources.Metier.Model;
using Human_Resources.Metier.Traitement;
using Microsoft.Owin.Security;
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
                AuthenticationProperties props;
                if (compte.Employe!=null)
                {
                    props = new AuthenticationProperties(new Dictionary<string, string>
                    {
                        {  "name", compte.Employe.Nom},
                        { "prenom", compte.Employe.Prenom },
                        { "role", compte.Role.Libelle}
                    });
                }
                else
                {
                    props = new AuthenticationProperties(new Dictionary<string, string>
                    {
                        { "name", ""},
                        { "prenom", "" },
                        { "role", compte.Role.Libelle}
                    });
                }

                var ticket = new AuthenticationTicket(identity, props);

                context.Validated(ticket);
            }
        }

        public override Task TokenEndpoint(OAuthTokenEndpointContext context)
        {
            foreach (KeyValuePair<string, string> property in context.Properties.Dictionary)
            {
                if(property.Key!=".issued" && property.Key != ".expires")
                    context.AdditionalResponseParameters.Add(property.Key, property.Value);

            }
            return Task.FromResult<object>(null);
        }


    }
}