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
            var controller = new HomeController(new TestAppContext());

            var result = controller.Index() as ViewResult;

            Assert.IsNotNull(result);
            Assert.IsNull(result.Model);
        }

        [TestMethod]
        public void TestMethod2()
        {
            var context = new TestAppContext();
            context.Npis.Add(new Npi() { Id = 1, Name = "Test1" });
            context.Npis.Add(new Npi() { Id = 2, Name = "Test2" });
            context.Npis.Add(new Npi() { Id = 3, Name = "Test3" });

            var controller = new HomeController(context);

            var result = controller.Edit(3) as ViewResult;

            Assert.IsNotNull(result);
            Assert.IsTrue(result.Model is HomeEditViewModel);
            var model = result.Model as HomeEditViewModel;
            Assert.AreEqual(3, model.Npi.Id);
            Assert.AreEqual("Test3", model.Npi.Name);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void TestMethod2a()
        {
            var context = new TestAppContext();
            context.Npis.Add(new Npi() { Id = 1, Name = "Test1" });
            context.Npis.Add(new Npi() { Id = 2, Name = "Test2" });
            context.Npis.Add(new Npi() { Id = 3, Name = "Test3" });

            var controller = new HomeController(context);

            var result = controller.Edit(99 /* Not legal */) as ViewResult;
            Assert.IsNull(result);
        }
    }
}
