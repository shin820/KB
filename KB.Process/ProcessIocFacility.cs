using Castle.MicroKernel;
using Castle.MicroKernel.Facilities;
using Castle.MicroKernel.Registration;
using KB.BizService;

namespace KB.Process
{
    public class ProcessIocFacility : AbstractFacility
    {
        protected override void Init()
        {
            Kernel.Register(
            Classes.FromAssemblyNamed("KB.Process").Pick().If(t => t.Name.EndsWith("Process"))
                    .Configure(configurer => configurer.Named(configurer.Implementation.Name))
                    .WithService.DefaultInterfaces().LifestylePerWebRequest()
            );

            BusinessServiceIocInitializer.Init(Kernel);
        }
    }
}
