using System;
using System.Web.Mvc;
using Acme.Portal.Core.DataModels;
using Acme.Portal.Web.Controllers;
using Acme.Portal.Web.Models.Home;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Acme.Portal.Test
{
    [TestClass]
    public class HomeControllerTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            var controller = new HomeController();

            var result = controller.Index() as ViewResult;

            Assert.IsNotNull(result);
            Assert.IsNull(result.Model);
        }

        [TestMethod]
        public void TestMethod2()
        {
            var controller = new HomeController();

            var result = controller.Edit(9) as ViewResult;

            Assert.IsNotNull(result);
            Assert.IsTrue(result.Model is HomeEditViewModel);
            var model = result.Model as HomeEditViewModel;
            Assert.AreEqual(9, model.Id);
            Assert.AreEqual("Mazda", model.Name);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void TestFail1()
        {
            var controller = new HomeController();

            var result = controller.Edit(99 /* Not legal */) as ViewResult;
            Assert.IsNull(result);
        }
    }
}
