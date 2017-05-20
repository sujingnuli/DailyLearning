using EBuy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EBuy.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "你是傻逼";

            return View();
        }

        public ActionResult About()
        {
            ViewBag.UserName = User.Identity.Name;
            var company = new CompanyInfo
            {
                Name = "EBuy:THE ASP.NET MVC Demo Site",
                Description = "EBuy the world leader of ASP.NET MVC Demo"
            };

            return View("About",company);
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "你他妈才是傻逼";

            return View();
        }
    }
}
