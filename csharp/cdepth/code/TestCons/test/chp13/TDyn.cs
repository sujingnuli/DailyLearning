using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestCons.test.chp13
{
    public class TDyn
    {
        public void test() {
            dynamic items = new List<int> { 1, 2, 3 };
            dynamic valueToAdd = 2;
            foreach (var item in items) {
                
                Console.WriteLine(item+valueToAdd);
            }
        }
    }
}
