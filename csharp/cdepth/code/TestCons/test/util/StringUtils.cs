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
    }
}
