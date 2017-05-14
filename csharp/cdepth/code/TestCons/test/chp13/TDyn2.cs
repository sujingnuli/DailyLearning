using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestCons.test.util;

namespace TestCons.test.chp13
{
    public class TDyn2
    {
       
        public void test() {
            byte[] bytes = new byte[] { 1, 2, 3 };
            Console.WriteLine(bytes.DynamicSum());
        }

        public void test2() {
            var times = new List<TimeSpan>{
                2.Hours(),3.Minutes(),30.Seconds()
            };
            Console.WriteLine(times.DynamicSum());
        }
    }
}
