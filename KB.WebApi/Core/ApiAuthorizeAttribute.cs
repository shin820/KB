using KB.Infrastructure.Runtime.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace KB.WebApi.Core
{
    public class ApiAuthorizeAttribute : AuthorizationFilterAttribute
    {
        public string Permissions { get; set; }

        public override Task OnAuthorizationAsync(HttpActionContext actionContext, System.Threading.CancellationToken cancellationToken)
        {

            var principal = actionContext.RequestContext.Principal as ClaimsPrincipal;

            if (principal == null || !principal.Identity.IsAuthenticated)
            {
                actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized);
                return Task.FromResult<object>(null);
            }

            if (string.IsNullOrWhiteSpace(Permissions))
            {
                return Task.FromResult<object>(null);
            }

            string[] permissions = Permissions.Split(',').Select(t => t.Trim().ToLower()).ToArray();
            if (permissions != null && permissions.Any())
            {
                foreach (var permission in permissions)
                {
                    bool hasClaim = principal.HasClaim(
                        x => x.Type == Comm100ClaimTypes.Permission && x.Value.Trim().ToLower() == permission
                        );

                    if (!hasClaim)
                    {
                        actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized);
                        return Task.FromResult<object>(null);
                    }
                }
            }

            return Task.FromResult<object>(null);

        }
    }
}