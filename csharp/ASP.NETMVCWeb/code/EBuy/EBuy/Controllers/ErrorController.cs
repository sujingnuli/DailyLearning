using Ebuy.Common.Filter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EBuy.Controllers
{
    public class ErrorController : Controller
    {
        public ActionResult NotFound() {
            return View();
        }
        public ActionResult serverExp() {
            return View();
        }
    }
}
