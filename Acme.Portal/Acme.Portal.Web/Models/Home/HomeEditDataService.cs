using System;
using System.Linq;
using Acme.Portal.Web.Controllers;

namespace Acme.Portal.Web.Models.Home
{
    public class HomeEditDataService
    {
        public HomeEditViewModel GetById(int id)
        {
            var npi = HomeController.CurrentContext.Npis.Find(id);
            if (npi != null)
                return new HomeEditViewModel(npi);
            else
            {
                throw new Exception("Bad Id");
            }
        }
    }
}