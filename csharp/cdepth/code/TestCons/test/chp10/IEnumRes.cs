using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestCons.test.chp10
{
    public class IEnumRes
    {
        public static void test() {
            var collection = Enumerable.Range(0, 9).Reverse();
            foreach (var item in collection) {
                Console.WriteLine(item);
            }
        }
    }
}
