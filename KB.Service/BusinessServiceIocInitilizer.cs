using Castle.MicroKernel;
using Castle.MicroKernel.Facilities;
using Castle.MicroKernel.Registration;
using KB.Repository;

namespace KB.BizService
{
    public class BusinessServiceIocInitializer
    {
        public static void Init(IKernel kernel)
        {
            kernel.Register(
            Classes.FromAssemblyNamed("KB.BizService").Pick().If(t => t.Name.EndsWith("Service"))
                    .Configure(configurer => configurer.Named(configurer.Implementation.Name))
                    .WithService.DefaultInterfaces().LifestylePerWebRequest()
            );

            RepositoryIocInitializer.Init(kernel);
        }
    }
}
