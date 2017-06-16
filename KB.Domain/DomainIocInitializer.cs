using Castle.MicroKernel;
using Castle.MicroKernel.Registration;
using KB.Domain.DomainServices;
using KB.Domain.Repositories;
using System.Data.Entity;

namespace KB.Domain
{
    public class DomainIocInitializer
    {
        public static void Init(IKernel kernel)
        {
            kernel.Register(

                Classes.FromAssemblyContaining<IDomainService>()
                        .BasedOn<IDomainService>()
                        .Configure(configurer => configurer.Named(configurer.Implementation.Name))
                        .WithServiceAllInterfaces()
                        .LifestylePerWebRequest(),

                Component.For(typeof(DbContext))
                        .UsingFactoryMethod(k => { return DbContextFactory.Create(k); })
                        .LifestylePerWebRequest(),

                Classes.FromAssemblyContaining(typeof(IRepositoryBase<>))
                       .BasedOn(typeof(RepositoryBase<>))
                       .Configure(configurer => configurer.Named(configurer.Implementation.Name))
                       .WithServiceAllInterfaces()
                       .LifestylePerWebRequest()
            );
        }
    }
}
