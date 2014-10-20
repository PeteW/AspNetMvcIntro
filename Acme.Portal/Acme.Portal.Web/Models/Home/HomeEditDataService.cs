using System;
using System.Linq;
using System.Transactions;
using Acme.Portal.Core.DataModels;
using Acme.Portal.Web.Controllers;

namespace Acme.Portal.Web.Models.Home
{
    public class HomeEditDataService
    {
        public HomeEditDataService(IDatabaseContext databaseContext)
        {
            DatabaseContext = databaseContext;
        }

        public IDatabaseContext DatabaseContext { get; set; }

        public HomeEditViewModel GetById(int id)
        {
            using (var context = new DatabaseContext())
            {
                return context.Npis.Where(x => x.Id == id)
                                 .Select(x => new HomeEditViewModel()
                                     {
                                         Id = x.Id,
                                         Name = x.Name
                                     }).Single();

            }
        }

        public void SaveOrUpdate(HomeEditViewModel viewModel)
        {
            using (var tx = new TransactionScope())
            using (var context = new DatabaseContext())
            {
                Npi npi;
                //insert if ID==0
                if (viewModel.Id == 0)
                {
                    npi = new Npi();
                    context.Npis.Add(npi);
                }
                //otherwise update
                else
                {
                    npi = context.Npis.Single(x => x.Id == viewModel.Id);
                }
                npi.Name = viewModel.Name;
                context.SaveChanges();
                tx.Complete();
            }
        }
    }
}