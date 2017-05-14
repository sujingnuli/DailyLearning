using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestCons.test.chp14
{
    public  class PrintCount
    {
        public static int CountImpl<T>(ICollection<T> collection) {
            return collection.Count;
        }
        public static int CountImpl(ICollection collection) {
            return collection.Count;
        }
        public static int CountImpl(string text) {
            return text.Length;
        }
        public static int CountImpl(IEnumerable collection) {
            int count = 0;
            foreach (var item in collection) {
                count++;
            }
            return count;
        }
        public static void PrintCon(IEnumerable collection) {
            dynamic d = collection;
            int count = CountImpl(d);
            Console.WriteLine(count);
        }

        public void test() {
            PrintCon(new BitArray(5));
            PrintCon(new HashSet<int> { 1, 2, 3 });
            PrintCon("ABC");
            PrintCon("ABCDEF".Where(c => c > 'B'));
        }
        public void test1() {
            var numbers = Enumerable.Range(10, 10);
            var t = numbers.Take(5);
        }
    }
}
