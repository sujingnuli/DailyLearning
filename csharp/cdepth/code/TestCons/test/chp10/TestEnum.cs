using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestCons.test.chp10
{
    public class TestEnum
    {
        public static void test(){
            var collection = Enumerable.Range(-5, 11).Select(x => new { org = x, square = x * x }).OrderBy(x => x.square).ThenBy(x => x.org);
            foreach (var item in collection) {
                Console.WriteLine(item);
            }
        }
    }
}
