using System;
using System.Linq;
using System.Web.Mvc;
using Acme.Portal.Core.DataModels;
using Acme.Portal.Web.Models.Home;
namespace Acme.Portal.Web.Controllers
{
    [HandleError]
    public class HomeController : Controller
    {
        static private IDatabaseContext DatabaseContext = new Acme.Portal.Core.DataModels.DatabaseContext();

        public static IDatabaseContext CurrentContext
        {
            get { return DatabaseContext; }
        }

        public HomeController()
        {
        }

        public HomeController(IDatabaseContext databaseContext)
        {
            DatabaseContext = databaseContext;
        }

        /// <summary>
        /// Display a list of NPIs.
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            try
            {
                var npis = CurrentContext.Npis.ToList();
            }
            catch (SystemException ex)
            {
                var msg = ex.Message;
            }

            return View();
        }


        /// <summary>
        /// Edits a specific Npi by ID.
        /// </summary>
        /// <param name="id">The unique identifier.</param>
        /// <returns></returns>
        public ActionResult Edit(int id)
        {
            var viewModel = new HomeEditDataService().GetById(id);
            return View(viewModel);
        }

        /// <summary>
        /// Edits the specified view model.
        /// </summary>
        /// <param name="viewModel">The view model.</param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Edit(HomeEditViewModel viewModel)
        {
            return View(viewModel);
        }
    }
}
