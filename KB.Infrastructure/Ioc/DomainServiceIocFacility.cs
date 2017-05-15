using Castle.MicroKernel.Facilities;
using Castle.MicroKernel.Registration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KB.Infrastructure.Ioc
{
    public class DomainServiceIocFacility : AbstractFacility
    {
        protected override void Init()
        {
            Kernel.Register(
            Classes.FromAssemblyNamed("KB.DomainService").Pick().If(t => t.Name.EndsWith("Service"))
                    .Configure(configurer => configurer.Named(configurer.Implementation.Name))
                    .WithService.DefaultInterfaces().LifestylePerWebRequest()
            );
        }
    }
}
