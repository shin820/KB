using KB.Infrastructure;
using KB.Infrastructure.Api;
using KB.Infrastructure.Runtime.Security;
using KB.WebApi.Models.Account;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.OAuth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;

namespace KB.WebApi.Controllers
{
    public class AccountController : ApiController
    {
        public static OAuthBearerAuthenticationOptions OAuthBearerOptions { get; private set; }

        static AccountController()
        {
            OAuthBearerOptions = new OAuthBearerAuthenticationOptions();
        }

        [Authorize(Roles = "developer")]
        [HttpGet]
        [Route("me")]
        public ApiResult<Me> Me()
        {
            ClaimsIdentity identity = Thread.CurrentPrincipal.Identity as ClaimsIdentity;
            var me = new Me
            {
                Id = identity.GetUserId<string>(),
                Name = identity.GetUserName(),
                Email = identity.Claims.FirstOrDefault(t => t.Type == ClaimTypes.Email).Value,
                SideId = identity.GetSideId()
            };

            return new ApiResult<Me>(me);
        }

        [HttpPost]
        [Route("token")]
        public ApiResult<string> Authenticate(AuthenticationModel model)
        {
            if (!ModelState.IsValid)
            {
                return new ApiResult<string>(new ErrorInfo("Invalid request!"));
            }

            //todo, validate user name and secret

            ClaimsIdentity claimsIdentity = new ClaimsIdentity(DefaultAuthenticationTypes.ApplicationCookie, ClaimTypes.NameIdentifier, ClaimTypes.Role);

            claimsIdentity.AddClaim(new Claim(ClaimTypes.NameIdentifier, "1"));
            claimsIdentity.AddClaim(new Claim(ClaimTypes.Name, "Shin"));
            claimsIdentity.AddClaim(new Claim(ClaimTypes.Email, "abc@123.com"));
            claimsIdentity.AddClaim(new Claim(ClaimTypes.Role, "developer"));
            claimsIdentity.AddClaim(new Claim(ClaimTypes.Role, "special user"));
            claimsIdentity.AddClaim(new Claim(Comm100ClaimTypes.SideId, "10000"));

            var ticket = new AuthenticationTicket(claimsIdentity, new AuthenticationProperties());
            ticket.Properties.IssuedUtc = DateTime.UtcNow;
            ticket.Properties.ExpiresUtc = DateTime.UtcNow.Add(TimeSpan.FromMinutes(30));

            return new ApiResult<string>(OAuthBearerOptions.AccessTokenFormat.Protect(ticket));
        }
    }
}
