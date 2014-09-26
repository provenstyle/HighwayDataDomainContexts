using System.Collections.Generic;
using System.Configuration;
using Highway.Data;
using Highway.Data.EventManagement.Interfaces;

namespace HighwayDomains.FirstDomainConfig
{
    public class FirstDomain : IDomain
    {
        public FirstDomain()
        {
            ConnectionString = ConfigurationManager.ConnectionStrings["FirstDomain"].ConnectionString;
            Mappings = new FirstMappingConfiguration();
            Context = new DefaultContextConfiguration();
            Events = new List<IInterceptor>();
        }

        public string ConnectionString { get; private set; }
        public IMappingConfiguration Mappings { get; private set; }
        public IContextConfiguration Context { get; private set; }
        public List<IInterceptor> Events { get; private set; }
    }
}