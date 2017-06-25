using Ebuy.Common.Binder;
using Ebuy.Common.Clz;
using Ebuy.Common.DataAccess;
using EBuy.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace EBuy
{
    // 注意: 有关启用 IIS6 或 IIS7 经典模式的说明，
    // 请访问 http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            //注册自定义链接。
            //RouteTable.Routes.MapConnection<EbuyCustomConnection>("echo", "echo/{*operation}");
            
            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            //BundleConfig.RegisterBundles(BundleTable.Bundles);
            //BundleTable.EnableOptimizations = true;//启动优化，把多个css,js文件放在一起，浏览器只发送一次请求。
            AuthConfig.RegisterAuth();
            //更换DefaultModelBinder
            ModelBinders.Binders.DefaultBinder = new JsonModelBinder();
            //设置默认解析器
            //GlobalConfiguration.Configuration.DependencyResolver = new NinjectWebApiResolver(kernel);
            //添加自定义Mime格式化器
            
        }
      
    }
}