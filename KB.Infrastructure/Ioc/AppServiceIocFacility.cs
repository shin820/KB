using Castle.MicroKernel;
using Castle.MicroKernel.Facilities;
using Castle.MicroKernel.Registration;

namespace KB.Infrastructure.Ioc
{
    public class AppServiceIocFacility : AbstractFacility
    {
        protected override void Init()
        {
            Kernel.Register(
            Classes.FromAssemblyNamed("KB.AppService").Pick().If(t => t.Name.EndsWith("AppService"))
                    .Configure(configurer => configurer.Named(configurer.Implementation.Name))
                    .WithService.DefaultInterfaces().LifestylePerWebRequest()
            );
        }
    }
}
