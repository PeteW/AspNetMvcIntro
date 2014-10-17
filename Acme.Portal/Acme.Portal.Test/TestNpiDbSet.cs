using System.Linq;
using Acme.Portal.Core.DataModels;

namespace Acme.Portal.Test
{
    class TestNpiDbSet : TestDbSet<Npi>
    {
        public override Npi Find(params object[] keyValues)
        {
            return this.SingleOrDefault(npi => npi.Id == (int)keyValues.Single());
        }
    }
}