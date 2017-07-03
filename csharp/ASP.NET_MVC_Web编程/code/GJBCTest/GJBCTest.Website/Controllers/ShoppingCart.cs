using GJBCTest.Website.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GJBCTest.Website.Controllers
{
    public class ShoppingCart : Controller
    {
        //
        // GET: /ShoppingCart/


        public static Cart GetCart(IController controller) {

            return new Cart();
        }

       
    }
}
