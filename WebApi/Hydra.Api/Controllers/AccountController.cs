using Hydra.Api.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using System.Security.Claims;
using Microsoft.Owin.Infrastructure;
using Hydra.Api.DTO;

namespace Hydra.Api.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "POST")]
    public class AccountController : ApiController
    {

        // POST: api/Account
        public string Post([FromBody]UserLoginDTO userDTO)
        {
            if (userDTO.Email == null && userDTO.Password == null) {
                return "";
            }
            HydraUserManager manager = Request.GetOwinContext().GetUserManager<HydraUserManager>();
            var userIdentity = manager.FindAsync(userDTO.Email, userDTO.Password).Result;
            if (userIdentity != null)
            {
                var identity = new ClaimsIdentity(Startup.OAuthBearerOptions.AuthenticationType);
                identity.AddClaim(new Claim(ClaimTypes.Name, userDTO.Email));
                identity.AddClaim(new Claim(ClaimTypes.NameIdentifier, userIdentity.Id));
                AuthenticationTicket ticket = new AuthenticationTicket(identity, new AuthenticationProperties());
                ticket.Properties.IssuedUtc = new SystemClock().UtcNow;
                ticket.Properties.ExpiresUtc = new SystemClock().UtcNow.Add(TimeSpan.FromDays(14));
                string accessToken = Startup.OAuthBearerOptions.AccessTokenFormat.Protect(ticket);

                return accessToken;
            }
            return "";
        }


    }
}
