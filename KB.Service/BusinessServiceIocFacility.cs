using Castle.MicroKernel;
using Castle.MicroKernel.Facilities;
using Castle.MicroKernel.Registration;
using KB.Repository;

namespace KB.BizService
{
    public class BusinessServiceIocFacility : AbstractFacility
    {
        protected override void Init()
        {
            Kernel.Register(
            Classes.FromAssemblyNamed("KB.BizService").Pick().If(t => t.Name.EndsWith("Service"))
                    .Configure(configurer => configurer.Named(configurer.Implementation.Name))
                    .WithService.DefaultInterfaces().LifestylePerWebRequest()
            );

            RepositoryIocInitializer.Init(Kernel);
        }
    }
}
