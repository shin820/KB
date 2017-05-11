using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using KB.Service;

namespace KB.WebApi.Core
{
    public class KBInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            ServiceIocInstaller.Install(container, store);
        }
    }
}