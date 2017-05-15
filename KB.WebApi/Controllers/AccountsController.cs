using KB.Infrastructure;
using KB.Infrastructure.Api;
using KB.Infrastructure.Authentication;
using KB.Infrastructure.Runtime.Security;
using KB.WebApi.Core;
using KB.WebApi.Models.Account;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.OAuth;
using System;
using System.Linq;
using System.Security.Claims;
using System.Threading;
using System.Web.Http;

namespace KB.WebApi.Controllers
{
    [RoutePrefix("api/accounts")]
    public class AccountsController : ApiController
    {
        public static OAuthBearerAuthenticationOptions OAuthBearerOptions { get; private set; }

        static AccountsController()
        {
            OAuthBearerOptions = new OAuthBearerAuthenticationOptions();
        }

        [ApiAuthorize(Permissions = "get_me")]
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

            ClaimsIdentity claimsIdentity = TestClaimsIdentity.Create();
            var ticket = new AuthenticationTicket(claimsIdentity, new AuthenticationProperties());
            ticket.Properties.IssuedUtc = DateTime.UtcNow;
            ticket.Properties.ExpiresUtc = DateTime.UtcNow.Add(TimeSpan.FromMinutes(30));

            return new ApiResult<string>(OAuthBearerOptions.AccessTokenFormat.Protect(ticket));
        }
    }
}
