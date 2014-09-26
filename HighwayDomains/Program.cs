using System;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using HighwayDomains.FirstDomainConfig;
using HighwayDomains.Repository;
using HighwayDomains.SecondDomainConfig;

namespace HighwayDomains
{
    class Program
    {
        static void Main()
        {
            var container = new WindsorContainer();
            container.Register(Component.For<IWindsorContainer>().Instance(container));
            container.Install(
                new FirstDomainInstaller(), 
                new SecondDomainInstaller()
            );
                
            var firstRepository = container.Resolve<IRepositoryFactory<FirstDomain>>();
            firstRepository.WithRepository(r =>
            {
                r.Context.Add(new FirstEntity {Name = "FirstEntity"});
                r.Context.Commit();
            });
            container.Release(firstRepository);


            var secondRepository = container.Resolve<IRepositoryFactory<SecondDomain>>();
            secondRepository.WithRepository(r =>
            {
                r.Context.Add(new SecondEntity {Name = "SecondEntity"});
                r.Context.Commit();
            });
            container.Release(secondRepository);


            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }
    }
}
