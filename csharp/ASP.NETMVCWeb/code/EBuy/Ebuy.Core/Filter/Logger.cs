using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ebuy.Common.Filter
{
    public class Logger
    {
        public static void LogException(Exception ex) {
            EventLog log = new EventLog();
            log.Source = "Ebuy";
            log.WriteEntry(ex.Message);
        }
    }
}
