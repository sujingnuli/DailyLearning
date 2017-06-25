using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Script.Serialization;

namespace EBuy.Filters
{
    public class RouteGenerator
    {
        private readonly RouteCollection _routes;
        private readonly RequestContext _requestContext;
        private readonly ControllerContext _controllerActions;
        private readonly JavaScriptSerializer _javaScriptSerializer;
        public RouteGenerator(RouteCollection routes, RequestContext requestContext, ControllerContext controllerActions) {
            Contract.Requires(routes!=null);
            Contract.Requires(requestContext!=null);
            Contract.Requires(controllerActions!=null);
            _routes = routes;
            _requestContext = requestContext;
            _controllerActions = controllerActions;
            _javaScriptSerializer = new JavaScriptSerializer();
        }
       // public virtual IEnumerable<RouteBase> Generator;
        
    }
}