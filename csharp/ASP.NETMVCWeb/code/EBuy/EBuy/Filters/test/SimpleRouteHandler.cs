using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;

namespace EBuy.Filters.test
{
    public class SimpleRouteHandler:IRouteHandler
    {
        private readonly RequestContext _requestContext;
        public IHttpHandler GetHttpHandler(RequestContext requestContext)
        {
            return new SimpleHandler(requestContext);
        }

    }
}