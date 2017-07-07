using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GJBCTest.Website.Models;
using GJBCTest.Website.Filters;

namespace GJBCTest.Website.Controllers
{
    public class StoreController : Controller
    {
        private MusicStoreDBContext db = new MusicStoreDBContext();

        public ActionResult Index()
        {
            var albums = db.Albums.Include(a => a.Genre).Include(a => a.Artist);

            return View(albums);
        }

        [MyAuthorize]
        public ActionResult Buy(int id)
        {
            var album = db.Albums.Single(a => a.AlbumId == id);

            //Charge the user and ship the album!!!
            return View(album);
        }

        public ActionResult DaliyDeal()
        {
            var album = db.Albums.OrderBy(m => m.Price).First();
            return PartialView("_DaliyDeal", album);
        }

        public ActionResult ArtistSearch(string q) {
            var artists = db.Artists.Where(m => m.Name.Contains(q)).ToList();
            return Json(artists, JsonRequestBehavior.AllowGet);
        }

        public ActionResult QuickSearch(string term) {
            var artists = db.Artists.Where(m => m.Name.Contains(term)).ToList().Select(m => new { value = m.Name });
            return Json(artists, JsonRequestBehavior.AllowGet);
        }
    }
}
