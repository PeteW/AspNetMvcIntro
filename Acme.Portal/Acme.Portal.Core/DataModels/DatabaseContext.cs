using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using Acme.Portal.Core.Configuration;

namespace Acme.Portal.Core.DataModels
{
    public class DatabaseContext : DbContext, IDatabaseContext
    {
        public DatabaseContext() : base(SettingsManager.MyAbilityConnectionString)
        {
        }
        public DbSet<Npi> Npi { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //gets rid of the annying attempts to create tables with plural names
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            base.OnModelCreating(modelBuilder);
        }

    }
}