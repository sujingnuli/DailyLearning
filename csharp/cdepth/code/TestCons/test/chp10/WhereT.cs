using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestCons.test.chp10
{
    public static class WhereT
    {
        public static IEnumerable<T> Where<T>(this IEnumerable<T> source, Func<T, bool> predicate) {
            if (source == null || predicate == null) {
                throw new ArgumentNullException();
            }
            return WhereImpl(source, predicate);
        }
        public static IEnumerable<T> WhereImpl<T>(IEnumerable<T> source, Func<T, bool> predicate) {
            foreach (T item in source) {
                if (predicate(item)) {
                    yield return item;
                }
            }
        }
    }

    public class Testxx
    {
        public void test()
        {
            IEnumerable<int> nums = Enumerable.Range(0, 99);
            foreach (int t in nums.Where(x => x % 4 == 0))
            {
                Console.WriteLine(t);
            }
        }
        public void test2() {
            List<string> strs = new List<string>();
            var souce= Enumerable.Range(0, 10).Where(x => x % 2 != 0).Reverse().Select(x => { return new { num = x, root = Math.Sqrt(x) }; });
            foreach (var item in souce) {
                Console.WriteLine("num={0},root={1}", item.num, item.root);
            }
            
        }
    }
}
