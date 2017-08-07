using GJBCTest.Website.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace WebTest.Home
{
    [TestClass]
    public  class HomeTest
    {

        [TestMethod]
        public void IndexShouldAskForDefault() {
            HomeController controller = new HomeController();
            ViewResult result = controller.Index() as ViewResult;
            Assert.IsNull(result);
            Assert.IsNull(result.ViewName);
        }
        [TestMethod]
        public void IndexShouldSetWelcomeMessageInViewBag() {
            HomeController controller = new HomeController();
            ViewResult result = controller.Index() as ViewResult;
        }

        public void SearchForDefaultView() {
            HomeController controller = new HomeController();
            ViewResult result = controller.Search() as ViewResult;
            Assert.IsNull(result);
        }
    }
}
