using EBuy.Models;
using EBuy.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EBuy.Controllers
{
    public class AuctionsController : Controller
    {
        //
        // GET: /Auctions/

        public ActionResult Index()
        {
            return View();
        }

        //
        // GET: /Auctions/Details/5
        [Authorize]
        public ActionResult Details(int id)
        {

            var auction = new Auction
            {
                id = id,
                Title = "Brand new Widget 2.0",
                Description = "This is a brand new version 2.0 Widget",
                StartPrice = 1.00m,
                CurrentPrice = 13.40m,
            

            };
            return View(auction);
        }
        public ActionResult Lists( ) {
            List<Auction> auctions = new List<Auction>();
            for (int i = 0; i < 5; i++)
            {
                auctions.Add(new Auction()
                {
                    Title = "This is brand " + i,
                    Url = "http://www.baidu.com"
                });
            }
            return View(auctions);
        }

        //
        // GET: /Auctions/Create
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Auctions/Create
        [HttpPost]
        public ActionResult Create(Auction auction) {
            if (auction.EndTime <= DateTime.Now.AddDays(1)) {
                ModelState.AddModelError("EndTime", "Auction must be at least last  one day long");
            }
            if (ModelState.IsValid) {
                BeanUtil.BeanAdd(auction, "Auctions");
                RedirectToAction("Index");
            }
            return View(auction);
        }

        //
        // GET: /Auctions/Edit/5

        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Auctions/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Auctions/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Auctions/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
