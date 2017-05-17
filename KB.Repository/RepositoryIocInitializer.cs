using Castle.MicroKernel;
using Castle.MicroKernel.Facilities;
using Castle.MicroKernel.Registration;

namespace KB.Repository
{
    public class RepositoryIocInitializer
    {
        public static void Init(IKernel kernel)
        {
            kernel.Register(Classes.FromAssemblyNamed("KB.Entity").Pick().If(t=>t.Name== "KBDataContext")
                                     .LifestylePerWebRequest(),
                            //Component.For(typeof(IRepositoryBase<>))
                            //         .ImplementedBy(typeof(RepositoryBase<>))
                            //         .LifestylePerWebRequest(),
                            Classes.FromAssemblyNamed("KB.Repository").Pick().If(t => t.Name.EndsWith("Repository"))
                                    .Configure(configurer => configurer.Named(configurer.Implementation.Name))
                                    .WithService.DefaultInterfaces().LifestylePerWebRequest()
                                );
        }
    }
}
