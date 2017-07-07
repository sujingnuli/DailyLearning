using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace GJBCTest.Website
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            
            routes.MapRoute("blog", "{year}/{month}/{day}", new { controller = "blog", action = "Index" }, new { year = @"\d{4}", month = @"\d{2}", day = @"\d{2}" });

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Store", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}