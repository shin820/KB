using Castle.MicroKernel.Facilities;
using Castle.MicroKernel.Registration;
using KB.DomainService;

namespace KB.ApplicationService
{
    public class AppServiceIocFacility : AbstractFacility
    {
        protected override void Init()
        {
            Kernel.Register(
            Classes.FromAssemblyNamed("KB.ApplicationService").Pick().If(t => t.Name.EndsWith("AppService"))
                    .Configure(configurer => configurer.Named(configurer.Implementation.Name))
                    .WithService.DefaultInterfaces().LifestylePerWebRequest()
            );

            DomainServiceIocInitializer.Init(Kernel);
        }
    }
}
