using System.Data.Entity;
using Acme.Portal.Core.Configuration;

namespace Acme.Portal.Core.DataModels
{
    public class DatabaseContext : DbContext, IDatabaseContext
    {
        public DatabaseContext():base(SettingsManager.MyAbilityConnectionString){}
        public DbSet<Npi> Npis { get; set; }
    }
}