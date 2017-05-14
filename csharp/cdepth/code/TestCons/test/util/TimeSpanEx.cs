using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestCons.test.util
{
    public static class TimeSpanEx
    {
        public static TimeSpan Hours(this int ts)
        {
            return new TimeSpan(0, ts, 0, 0, 0);
        }
        public static TimeSpan Minutes(this int ts)
        {
            return new TimeSpan(0, 0, ts, 0, 0);
        }
        public static TimeSpan Seconds(this int ts)
        {
            return new TimeSpan(0, 0, 0, ts, 0);
        }
    }
}
