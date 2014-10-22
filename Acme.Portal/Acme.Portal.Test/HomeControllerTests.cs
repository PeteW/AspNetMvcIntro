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
        public void TestIndexDefault()
        {
            var controller = new HomeController();
            var expectedPage = 0;

            var result = controller.Index() as ViewResult;

            Assert.IsNotNull(result);
            Assert.IsTrue(result.Model is HomeIndexViewModel);
            var model = result.Model as HomeIndexViewModel;
            Assert.AreEqual(expectedPage, model.Page);
        }

        [TestMethod]
        public void TestIndexNull()
        {
            var controller = new HomeController();
            var expectedPage = 0;

            var result = controller.Index(null) as ViewResult;

            Assert.IsNotNull(result);
            Assert.IsTrue(result.Model is HomeIndexViewModel);
            var model = result.Model as HomeIndexViewModel;
            Assert.AreEqual(expectedPage, model.Page);
        }

        [TestMethod]
        public void TestIndexMinus1()
        {
            var controller = new HomeController();
            var expectedPage = 0;
            var requestedPage = -1;

            var result = controller.Index(requestedPage) as ViewResult;

            Assert.IsNotNull(result);
            Assert.IsTrue(result.Model is HomeIndexViewModel);
            var model = result.Model as HomeIndexViewModel;
            Assert.AreEqual(expectedPage, model.Page);
        }

        [TestMethod]
        public void TestIndexPage2()
        {
            var controller = new HomeController();
            var expectedPage = 2;
            var requestedPage = 2;

            var result = controller.Index(requestedPage) as ViewResult;

            Assert.IsNotNull(result);
            Assert.IsTrue(result.Model is HomeIndexViewModel);
            var model = result.Model as HomeIndexViewModel;
            Assert.AreEqual(expectedPage, model.Page);
        }

        [TestMethod]
        public void TestEditValid()
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
        public void TestEditFail()
        {
            var controller = new HomeController();

            var result = controller.Edit(99 /* Not legal */) as ViewResult;
            Assert.IsNull(result);
        }
    }
}
