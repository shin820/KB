using Castle.MicroKernel;
using Castle.MicroKernel.Facilities;
using Castle.MicroKernel.Registration;
using KB.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KB.Repository
{
    public class RepositoryIocFacility : AbstractFacility
    {
        protected override void Init()
        {
            Kernel.Register(Component.For<KBDataContext>()
                                     .ImplementedBy<KBDataContext>()
                                     .LifestylePerWebRequest(),
                            Component.For(typeof(IRepositoryBase<>))
                                     .ImplementedBy(typeof(RepositoryBase<>))
                                     .LifestylePerWebRequest(),
                            Classes.FromThisAssembly().Pick().If(t => t.Name.EndsWith("Repository"))
                                    .Configure(configurer => configurer.Named(configurer.Implementation.Name))
                                    .WithService.DefaultInterfaces().LifestylePerWebRequest()
                                );
        }
    }
}
