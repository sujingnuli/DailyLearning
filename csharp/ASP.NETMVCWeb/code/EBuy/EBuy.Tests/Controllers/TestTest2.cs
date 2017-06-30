using EBuy.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EBuy.Tests.Controllers
{
    [TestClass]
    public class TestTest2
    {
        [TestMethod]
        public void testExp() {
            Exception ex = new Exception("hahaha");
            Test2Controller t2 = new Test2Controller();
            t2.test1(ex);
         }
    }
}
