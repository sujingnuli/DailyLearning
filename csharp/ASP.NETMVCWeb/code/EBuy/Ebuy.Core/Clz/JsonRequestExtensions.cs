using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Ebuy.Common.Json
{
    public static class JsonRequestExtensions
    {
        public static bool IsJsonRequest(this HttpRequestBase request) {
            return string.Equals(request["format"], "json");
        }
    }
}
