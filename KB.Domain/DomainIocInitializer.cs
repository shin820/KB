using Castle.MicroKernel;
using Castle.MicroKernel.Registration;
using System.Data.Entity;

namespace KB.Domain
{
    public class DomainIocInitializer
    {
        public static void Init(IKernel kernel)
        {
            kernel.Register(
                Classes.FromAssemblyNamed("KB.Domain")
                        .Pick()
                        .If(t => t.Name.EndsWith("Service"))
                        .Configure(configurer => configurer.Named(configurer.Implementation.Name))
                        .WithService
                        .DefaultInterfaces()
                        .LifestylePerWebRequest(),

                Component.For(typeof(DbContext))
                        .UsingFactoryMethod(k => { return DbContextFactory.Create(k); })
                        .LifestylePerWebRequest(),
                Classes.FromAssemblyNamed("KB.Domain")
                       .Pick()
                       .If(t => t.Name.EndsWith("Repository"))
                       .Configure(configurer => configurer.Named(configurer.Implementation.Name))
                       .WithService
                       .DefaultInterfaces()
                       .LifestylePerWebRequest()
            );
        }
    }
}
