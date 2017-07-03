using GJBCTest.Website.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GJBCTest.Website.Controllers
{
    public class StoreController : Controller
    {
        private MusicStoreDBContext db = new MusicStoreDBContext();
        public ActionResult Index() {
            var albums = db.Albums;
            return View(albums);
        }
        [Authorize]
        public ActionResult Buy(int id) {
            var album = db.Albums.Single(m => m.AlbumId == id);

            return View(album);     
        }
    }
}
