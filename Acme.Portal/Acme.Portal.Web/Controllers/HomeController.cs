using System;
using System.Linq;
using System.Web.Mvc;
using Acme.Portal.Core.DataModels;
using Acme.Portal.Core.Utils;
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
        public ActionResult Index(int? id = 0)
        {
            int page = id ?? 0;
            page = page >= 0 ? page : 0;

            var viewModel = new HomeIndexDataService(DatabaseContext).GetPage(page, 3);
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult IndexUpdate(int? id = 0)
        {
            int page = id ?? 0;
            page = page >= 0 ? page : 0;

            var viewModel = new HomeIndexDataService(DatabaseContext).GetPage(page, 3);
            return PartialView("_IndexViewList", viewModel);
        }

        /// <summary>
        /// Edits a specific Npi by ID.
        /// </summary>
        /// <param name="id">The unique identifier.</param>
        /// <returns></returns>
        public ActionResult Edit(int id)
        {
            var viewModel = new HomeEditDataService(DatabaseContext).GetById(id);
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
            new HomeEditDataService(DatabaseContext).SaveOrUpdate(viewModel);
            return RedirectToAction("Index");
        }
    }
}
