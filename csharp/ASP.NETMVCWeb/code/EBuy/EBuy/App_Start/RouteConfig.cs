﻿using EBuy.Filters;
using EBuy.Filters.test;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace EBuy
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
           
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.RouteExistingFiles = false;
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
            routes.Add(new Route("{controller}/{action}/{id}",new SimpleRouteHandler()));
            routes.MapRoute("AspCompatRoute", "{controller}/{action}").RouteHandler = new AspCompatRouteHandler();
        }
    }
}