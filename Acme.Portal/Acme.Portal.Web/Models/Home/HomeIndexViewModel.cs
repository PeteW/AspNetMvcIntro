using System.Collections.Generic;
using Acme.Portal.Core.DataModels;

namespace Acme.Portal.Web.Models.Home
{
    public class HomeIndexViewModel
    {
        public int Page { get; set; }
        public List<Npi> Npis { get; set; }
    }
}