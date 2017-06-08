using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EBuy.Controllers
{
    [Authorize]
    public class HomeController:Controller
    {
        [Authorize]
        public ActionResult About(string returnUrl) {
            return View();
        }
    }
}