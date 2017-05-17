using Castle.MicroKernel;
using Castle.MicroKernel.Facilities;
using Castle.MicroKernel.Registration;
using System.Data.Entity;
using KB.Entity;

namespace KB.Repository
{
    public class RepositoryIocInitializer
    {
        public static void Init(IKernel kernel)
        {
            kernel.Register(Component.For(typeof(DbContext))
                                     .UsingFactoryMethod(k => { return DbContextFactory.Create(k); })
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
