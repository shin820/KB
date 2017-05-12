using Castle.MicroKernel;
using Castle.MicroKernel.Facilities;
using Castle.MicroKernel.Registration;

namespace KB.Infrastructure.Ioc
{
    public class RepositoryIocFacility : AbstractFacility
    {
        protected override void Init()
        {
            Kernel.Register(Classes.FromAssemblyNamed("KB.Entity").Pick().If(t=>t.Name== "KBDataContext")
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
