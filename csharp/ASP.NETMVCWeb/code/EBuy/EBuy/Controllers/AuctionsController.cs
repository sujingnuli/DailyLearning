using Ebuy.Common.Entities;
using Ebuy.Common.Inter;
using EBuy.Filters;
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
        private readonly IRepository _repository;
        public AuctionsController(IRepository repository)
        {
            this._repository=repository;
        }
        //
        // GET: /Auctions/

        public ActionResult Index()
        {
            return View();
        }

        //
        // GET: /Auctions/Details/5
        [MultipleResponseFormats]
        public ActionResult Auction(long id) {
            Auction auction=BeanUtil.GetById<Auction>(id,"Auctions");

            return View("Auction",auction);
        }
       

        public ActionResult Lists() {
            //List<Auction> auctions = BeanUtil.GetSelTable<Auction>("Auctions", "", "");
           // var auctions = _repository.All<Auction>();
           return View();
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
