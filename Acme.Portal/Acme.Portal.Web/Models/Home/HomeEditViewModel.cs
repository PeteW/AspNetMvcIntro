using Acme.Portal.Core.DataModels;

namespace Acme.Portal.Web.Models.Home
{
    public class HomeEditViewModel
    {
        public Npi Npi { get; set; }

        public HomeEditViewModel(Npi npi)
        {
            Npi = npi;
        }
    }
}