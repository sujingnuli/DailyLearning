using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GJBCTest.Website.Controllers
{
    public class ShoppingCartController : Controller
    {

        public ActionResult AddToCart(int id) {
            return View();
        }
    }
}
