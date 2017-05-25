using EBuy.Filters;
using EBuy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EBuy.Controllers
{
    public class AuctionController : Controller
    {
        public ActionResult Auction(long id) {
            var context = new EBuyContext();
            var auction = context.Auctions.FirstOrDefault(x => x.id == id);
            return View("auction", auction);
        }

       
    }
}
