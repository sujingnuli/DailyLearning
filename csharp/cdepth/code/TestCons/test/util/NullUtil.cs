using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestCons.test.util
{
    public static class NullUtil
    {
        public static bool IsNull(this object x){
            return x == null;
        }
        public static bool IsNullOrEmpty(this string x) {
            return string.IsNullOrEmpty(x);
        }
    }
}
