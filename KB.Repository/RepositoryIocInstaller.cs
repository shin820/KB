using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KB.Repository
{
    public static class RepositoryIocInstaller
    {
        public static void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.AddFacility<RepositoryIocFacility>();
        }
    }
}
