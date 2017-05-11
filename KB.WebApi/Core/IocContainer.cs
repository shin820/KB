using Castle.Windsor;
using KB.WebApi.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace KB.WebApi.Core
{
    public static class IocContainer
    {
        private static IWindsorContainer _container;

        public static void Setup()
        {
            _container = new WindsorContainer().Install(
                new ControllersInstaller(),
                new KBInstaller()
                );

            GlobalConfiguration.Configuration.DependencyResolver = new CastleDependencyResolver(_container.Kernel);
        }
    }
}