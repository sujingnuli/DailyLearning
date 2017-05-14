using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestCons.test.chp13


{
    public class TDuck
    {
        public static void PrintCount(IEnumerable collection) {
            dynamic d = collection;
            int count = d.Count;
            Console.WriteLine(count);
        }
        /***
         * BitArray - ICollecition
         * HashSet - ICollection<int>
         * List  -   ICollection ,ICollection<int>
         * 使用Duck类型，访问Count属性
         * */
        public void test() {
            PrintCount(new BitArray(10));
            PrintCount(new HashSet<int> { 3, 5 });
            PrintCount(new List<int> { 1, 2, 3 });
        }
    }
}
