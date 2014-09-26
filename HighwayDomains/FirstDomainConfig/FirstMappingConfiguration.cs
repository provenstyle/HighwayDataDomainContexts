using System.Data.Entity;
using Highway.Data;

namespace HighwayDomains.FirstDomainConfig
{
    public class FirstMappingConfiguration : IMappingConfiguration
    {
        public void ConfigureModelBuilder(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FirstEntity>();
        }
    }
}