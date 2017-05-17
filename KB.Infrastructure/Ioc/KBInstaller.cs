using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;

namespace KB.Infrastructure.Ioc
{
    public class KBInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.AddFacility<RepositoryIocFacility>();
            container.AddFacility<BusinessServiceIocFacility>();
        }
    }
}