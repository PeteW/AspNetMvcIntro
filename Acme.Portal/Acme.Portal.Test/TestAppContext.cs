using System.Data.Entity;
using Acme.Portal.Core.DataModels;

namespace Acme.Portal.Test
{
    public class TestAppContext : IDatabaseContext
    {
        public TestAppContext()
        {
            this.Npis = new TestNpiDbSet();
        }

        public DbSet<Npi> Npis { get; set; }

        public int SaveChanges()
        {
            return 0;
        }

        public void MarkAsModified(Npi item) { }
        public void Dispose() { }
    }
}