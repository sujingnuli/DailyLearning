using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestCons.test.chp10
{
    public class TestYY
    {
        public void test() {
            IEnumerable<int> nums = Enumerable.Range(0, 99);
            foreach (int t in nums.Where(x=>x%4==0)) {
                Console.WriteLine(t);
            }
        }
    }
}
