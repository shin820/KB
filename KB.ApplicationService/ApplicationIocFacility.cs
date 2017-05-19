using Castle.MicroKernel.Facilities;
using Castle.MicroKernel.Registration;
using KB.Domain;

namespace KB.Application
{
    public class ApplicationIocFacility : AbstractFacility
    {
        protected override void Init()
        {
            Kernel.Register(
            Classes.FromAssemblyNamed("KB.Application").Pick().If(t => t.Name.EndsWith("AppService"))
                    .Configure(configurer => configurer.Named(configurer.Implementation.Name))
                    .WithService.DefaultInterfaces().LifestylePerWebRequest()
            );

            DomainIocInitializer.Init(Kernel);
        }
    }
}
