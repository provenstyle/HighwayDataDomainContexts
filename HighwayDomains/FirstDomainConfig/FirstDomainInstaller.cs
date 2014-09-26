using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using Highway.Data;
using Highway.Data.Repositories;
using HighwayDomains.Repository;

namespace HighwayDomains.FirstDomainConfig
{
    public class FirstDomainInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(
                Component.For<FirstDomain>(),
                Component.For<IDomainContext<FirstDomain>>().ImplementedBy<DomainContext<FirstDomain>>(),
                Component.For<IDomainRepository<FirstDomain>>().ImplementedBy<DomainRepository<FirstDomain>>()
                    .DependsOn(Dependency.OnComponent<IDomain, FirstDomain>()),
                Component.For<IRepositoryFactory<FirstDomain>>().ImplementedBy<RepositoryFactory<FirstDomain>>()
            );
        }
    }
}
