using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;

namespace EBuy.Filters.test
{
    public class SimpleHandler:IHttpHandler
    {
        private readonly RequestContext _requestContext;
        public SimpleHandler(RequestContext requestContext) {
            _requestContext = requestContext;
        }



        public bool IsReusable
        {
            get { throw new NotImplementedException(); }
        }

        public void ProcessRequest(HttpContext context)
        {
            throw new NotImplementedException();
        }
    }
}