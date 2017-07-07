using GJBCTest.Website.Filters;
using GJBCTest.Website.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GJBCTest.Website.Controllers
{
    [MyAuthorize]
    public class CheckoutController : Controller
    {
        private MusicStoreDBContext db = new MusicStoreDBContext();


        public ActionResult AddressAndPayment() {
            return View();
        }
        [Authorize]
        [HttpPost]
        public ActionResult AddressAndPayment(Order newOrder) {
            if (ModelState.IsValid) {
                newOrder.UserName = User.Identity.Name;
                newOrder.OrderDate = DateTime.Now;
                db.Orders.Add(newOrder);
                db.SaveChanges();

                //process the order
                
              
            }
            return View(newOrder);
        }
    }
}
