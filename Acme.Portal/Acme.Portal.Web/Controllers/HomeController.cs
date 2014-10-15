using System.Web.Mvc;
using Acme.Portal.Web.Models.Home;

namespace Acme.Portal.Web.Controllers
{
    public class HomeController : Controller
    {
        /// <summary>
        /// Display a list of NPIs.
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
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
            
        }
    }
}
