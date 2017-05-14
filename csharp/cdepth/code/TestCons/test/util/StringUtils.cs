using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestCons.test.util
{
    public static class StringUtils
    {
        public static string PureStr(this object t) {
          return   t == null ? "" : t.ToString().Trim();
        }

        public static T DynamicSum<T>(this IEnumerable<T> source) {
            dynamic total = default(T);
            foreach (T element in source) {
                total = (T)(element + total);
            }
            return total;
        }
    }
}
