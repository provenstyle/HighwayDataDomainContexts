using System;
using System.Collections.Generic;
using Highway.Data;

namespace HighwayDomains.Repository
{
    public interface IRepositoryFactory<TD> where TD: class, IDomain
    {
        void WithRepository(Action<IRepository> action);
        IEnumerable<T> Find<T>(IQuery<T> queryObject);
        T Find<T>(IScalar<T> queryObject) where T : new();
        void Execute(Command command);
    }
}