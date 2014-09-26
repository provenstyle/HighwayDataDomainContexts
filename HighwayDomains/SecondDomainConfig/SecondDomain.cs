using System.Collections.Generic;
using System.Configuration;
using Highway.Data;
using Highway.Data.EventManagement.Interfaces;

namespace HighwayDomains.SecondDomainConfig
{
    public class SecondDomain : IDomain
    {
        public SecondDomain()
        {
            ConnectionString = ConfigurationManager.ConnectionStrings["SecondDomain"].ConnectionString;
            Mappings = new SecondMappingConfiguration();
            Context = new DefaultContextConfiguration();
            Events = new List<IInterceptor>();
        }

        public string ConnectionString { get; private set; }
        public IMappingConfiguration Mappings { get; private set; }
        public IContextConfiguration Context { get; private set; }
        public List<IInterceptor> Events { get; private set; }
    }
}