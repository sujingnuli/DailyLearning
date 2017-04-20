using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestCons.test.chp11
{
    public class CastOfType
    {
        public void test() {
            ArrayList list = new ArrayList{ "First", "Second", "Third" };
            IEnumerable strs = list.Cast<string>();
            foreach (var str in strs) {
                Console.WriteLine(str);
            }
            list = new ArrayList { 1, "I am not an int", 2, 3 };
            IEnumerable<int> ints = list.OfType<int>();
            foreach (int item in ints) {
                Console.WriteLine(item);
            }
        }
    }
}
