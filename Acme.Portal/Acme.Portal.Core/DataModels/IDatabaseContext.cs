using System;
using System.Data.Entity;

namespace Acme.Portal.Core.DataModels
{
    public interface IDatabaseContext : IDisposable
    {
        DbSet<Npi> Npis { get; set; }
    }
}