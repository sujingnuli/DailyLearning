using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestWeb.Entities;

namespace TestWeb.Chp4
{
    [TestClass]
    public class test1
    {
        [TestMethod]
        public void Test11() {
            Object o = new Object();
            bool t1 = (o is Object);
            bool t2 = (o is string);
            Console.WriteLine(t1 + "," + t2);
        }
        [TestMethod]
        public void Test12() {
            Object o = new Object();
            Employee e = o as Employee;
            if (o != null) {
                Console.WriteLine(o.ToString());
            }
        }
    }
}
