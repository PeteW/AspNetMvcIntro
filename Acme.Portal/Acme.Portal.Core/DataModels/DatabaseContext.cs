using System.Data.Entity;

namespace Acme.Portal.Core.DataModels
{
    public class DatabaseContext : DbContext, IDatabaseContext
    {
        public DbSet<Npi> Npis { get; set; }
    }
}