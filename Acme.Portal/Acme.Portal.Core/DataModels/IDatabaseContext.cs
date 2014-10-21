using System;
using System.Data.Entity;

namespace Acme.Portal.Core.DataModels
{
    public interface IDatabaseContext : IDisposable
    {
        DbSet<Npi> Npi { get; set; }
    }
}