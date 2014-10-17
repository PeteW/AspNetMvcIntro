using System;
using System.Web.Mvc;
using Acme.Portal.Web.Controllers;
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
            Assert.AreEqual("Index", result.ViewName);

        }

        [TestMethod]
        public void TestMethod2()
        {
            var controller = new HomeController();
            var result = controller.Edit(3) as ViewResult;
            Assert.AreEqual("Edit", result.ViewName);

        }
    }
}
