using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using Highway.Data;
using Highway.Data.Repositories;
using HighwayDomains.Repository;

namespace HighwayDomains.SecondDomainConfig
{
    public class SecondDomainInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(
                Component.For<SecondDomain>(),
                Component.For<IDomainContext<SecondDomain>>().ImplementedBy<DomainContext<SecondDomain>>(),
                Component.For<IDomainRepository<SecondDomain>>().ImplementedBy<DomainRepository<SecondDomain>>()
                    .DependsOn(Dependency.OnComponent<IDomain, SecondDomain>()),
                Component.For<IRepositoryFactory<SecondDomain>>().ImplementedBy<RepositoryFactory<SecondDomain>>()
            );
        }
    }
}
