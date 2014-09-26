using System;
using System.Collections.Generic;
using System.Linq;
using Castle.Windsor;
using Highway.Data;
using Highway.Data.Repositories;

namespace HighwayDomains.Repository
{
    public class RepositoryFactory<TD> : IRepositoryFactory<TD> where TD : class, IDomain
    {
        private readonly IWindsorContainer _container;

        public RepositoryFactory(IWindsorContainer container)
        {
            _container = container;
        }

        public void WithRepository(Action<IRepository> action)
        {
            var repo = Create();
            try
            {
                action.Invoke(repo);
            }
            finally
            {
                Release(repo);
            }
        }

        public IEnumerable<T> Find<T>(IQuery<T> queryObject)
        {
            var result = Enumerable.Empty<T>();
            WithRepository(repo => result = repo.Find(queryObject).ToArray());
            return result;
        }

        public T Find<T>(IScalar<T> queryObject) where T : new()
        {
            var result = default(T);
            WithRepository(repo => result = repo.Find(queryObject));
            return result;
        }

        public void Execute(Command command)
        {
            WithRepository(repo => repo.Execute(command));
        }

        public IRepository Create()
        {
            return _container.Resolve<IDomainRepository<TD>>() as IRepository;
        }

        public void Release(IRepository repository)
        {
            _container.Release(repository);
        }
    }
}