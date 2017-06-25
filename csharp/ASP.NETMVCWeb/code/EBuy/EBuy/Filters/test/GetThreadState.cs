using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;

namespace EBuy.Filters.test
{
    public class GetThreadState
    {
        public string ThreadState() {
            Thread thread = System.Threading.Thread.CurrentThread;
            ApartmentState state = thread.GetApartmentState();
            return state.ToString();
        }
    }
}