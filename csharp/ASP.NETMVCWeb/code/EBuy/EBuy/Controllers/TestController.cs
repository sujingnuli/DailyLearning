using Ebuy.Common.Filter;
using EBuy.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;

namespace EBuy.Controllers
{
    public class TestController : Controller
    {
     
        public ActionResult TestAjax1() {
            return View();
        }
        public ActionResult Test() {
            return View();
        }

        public ActionResult Test1() {
            return View();    
        }
        public ActionResult Test2() {
            return View();
        }

        [OutputCache(Duration=10,VaryByParam="none",Location=OutputCacheLocation.Client)]
        public ActionResult Test3() {
            ViewBag.Message = DateTime.Now.ToString();
            return View();
        }

        public ActionResult Test4() {
            
            return View();
        }

        /// <summary>
        /// 设置缓存头
        /// </summary>
        /// <returns></returns>
        public ActionResult CacheDemo() {
            //设置是否允许客户端或者代理使用缓存
            Response.Cache.SetCacheability(HttpCacheability.Public);
            //设置缓存的最大有效时间
            Response.Cache.SetMaxAge(TimeSpan.FromMinutes(20));
            //设置过期时间
            Response.Cache.SetExpires(DateTime.Parse("12:00:00PM"));
            return View();
        }
        [Route("test/{key}-{title}/go")]
        public ActionResult Test5(string key,string title) {
            ViewBag.Key = key;
            ViewBag.Title = title;
            return View();
        }
        public ActionResult Test6() {
            try
            {
                throw new Exception("this is test 6' exception");
            }
            catch (Exception ex) {
                Logger.LogException(ex);
            }
            return View();
        }

        protected override void OnException(ExceptionContext filterContext)
        {
            if (filterContext == null) {
                base.OnException(filterContext);
            }
            Logger.LogException(filterContext.Exception);
            if (filterContext.HttpContext.IsCustomErrorEnabled) { 
                //如果启用了全局错误过滤器，就不需要下面的代码
                filterContext.ExceptionHandled = true;
                this.View("Error").ExecuteResult(this.ControllerContext);
            }
        }
    }
}
