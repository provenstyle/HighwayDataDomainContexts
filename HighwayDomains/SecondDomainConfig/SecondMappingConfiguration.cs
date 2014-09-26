using System.Data.Entity;
using Highway.Data;

namespace HighwayDomains.SecondDomainConfig
{
    public class SecondMappingConfiguration : IMappingConfiguration
    {
        public void ConfigureModelBuilder(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SecondEntity>();
        }
    }
}