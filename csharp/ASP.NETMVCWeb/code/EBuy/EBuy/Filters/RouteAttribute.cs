using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EBuy.Filters
{
    [AttributeUsage(AttributeTargets.Method,Inherited=true,AllowMultiple=true)]
    public class RouteAttribute:Attribute
    {
        public string Constraints { get; set; }
        public string Defaults { get; set; }
        public string Pattern { get; set; }
        public RouteAttribute(string pattern) {
            Pattern = pattern;
        }
    }
}