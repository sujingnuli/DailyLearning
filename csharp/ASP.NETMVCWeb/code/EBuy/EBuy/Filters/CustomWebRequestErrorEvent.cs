using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Management;

namespace EBuy.Filters
{
    public class CustomWebRequestErrorEvent:WebRequestErrorEvent
    {
        public CustomWebRequestErrorEvent(string message,object eventSource,int eventCode,Exception exception)
            :base(message,eventSource,eventCode,exception)
        {
            
        }
        public CustomWebRequestErrorEvent(string message, object eventSource, int eventCode, int eventDetailCode, Exception exception)
            : base(message, eventSource, eventCode, eventDetailCode, exception) { 
            
        }
    }
}