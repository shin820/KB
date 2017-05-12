using KB.WebApi.App_Start;
using KB.WebApi.Controllers;
using Microsoft.Owin;
using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
[assembly: OwinStartup(typeof(Startup))]

namespace KB.WebApi.App_Start
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.UseOAuthBearerAuthentication(AccountController.OAuthBearerOptions);
        }
    }
}