using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestCons.test.util;

namespace TestCons.test.chp10
{
    public class NullEx
    {
        public static void test() {
            object y = null;
            Console.WriteLine(y.IsNull());
            y = new object();
            Console.WriteLine(y.IsNull());
        }
        public static void test2() {
            string x = null;
            Console.WriteLine(x.IsNullOrEmpty());
            x = "Hello World";
            Console.WriteLine(x.IsNullOrEmpty());
          
        }
    }
}
