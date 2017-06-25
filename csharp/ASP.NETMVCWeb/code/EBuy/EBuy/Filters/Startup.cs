﻿using Microsoft.AspNet.SignalR;
using Microsoft.Owin;
using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

[assembly: OwinStartupAttribute(typeof(EBuy.Filters.Startup))]
namespace EBuy.Filters
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {

            //app.Map("/echo", map =>
            //{
            //    map.RunSignalR<EbuyCustomConnection>();
            //});
            app.MapSignalR("/realtime", new HubConfiguration());
        }
    }
}