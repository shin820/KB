using AutoMapper;
using KB.WebApi.Core;
using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace KB.WebApi
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(HttpApplication));

        protected void Application_Start()
        {
            log.Info("Application starting...");

            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            IocContainer.Setup();

            Mapper.Initialize(cfg =>
                cfg.AddProfiles(new[] {
                    "KB.Application"
                })
            );

            log.Info("Application started...");
        }

        protected void Application_Error()
        {
            var raisedException = Server.GetLastError();
            if (raisedException != null)
            {
                log.Error(raisedException.Message, raisedException);
            }
        }
    }
}
