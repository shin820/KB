using Castle.MicroKernel;
using Castle.MicroKernel.Facilities;
using Castle.MicroKernel.Registration;

namespace KB.Infrastructure.Ioc
{
    public class BusinessServiceIocFacility : AbstractFacility
    {
        protected override void Init()
        {
            Kernel.Register(
            Classes.FromAssemblyNamed("KB.BusinessService").Pick().If(t => t.Name.EndsWith("Service"))
                    .Configure(configurer => configurer.Named(configurer.Implementation.Name))
                    .WithService.DefaultInterfaces().LifestylePerWebRequest()
            );
        }
    }
}
