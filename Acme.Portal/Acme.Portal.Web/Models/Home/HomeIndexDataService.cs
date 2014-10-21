using System.Linq;
using Acme.Portal.Core.DataModels;

namespace Acme.Portal.Web.Models.Home
{
    public class HomeIndexDataService
    {
        public IDatabaseContext DatabaseContext { get; set; }

        public HomeIndexDataService(IDatabaseContext databaseContext)
        {
            DatabaseContext = databaseContext;
        }

        public HomeIndexViewModel GetPage(int page, int count)
        {
            using (var context = new DatabaseContext())
            {
                var vm = new HomeIndexViewModel
                {
                    Page = page,
                    Npis = context.Npi.OrderBy(x => x.Id).Skip(page * count).Take(count).ToList()
                };
                return vm;
            }
        }
    }
}