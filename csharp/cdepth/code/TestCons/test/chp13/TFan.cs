using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestCons.test.chp13
{
    public class TFan
    {
        public void test() {
            List<string> list = new List<string> { "ss", "tt" };
            string item = "Hello";
            bool t=    AddConditionally(list, item);
            list.ForEach(str =>
            {
                Console.WriteLine(str);
            });
        }
        private static bool AddConditionallyImpl<T>(List<T> list, T item) {
            if (list.Count < 10) {
                list.Add(item); return true;
            }
            return false;
        }
        public static bool AddConditionally(dynamic list, dynamic item) {
          return   AddConditionallyImpl(list, item);
        }
    }
}
