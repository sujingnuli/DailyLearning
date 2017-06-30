using GJBCTest.Website.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GJBCTest.Website.Controllers
{
    public class AlbumController : Controller
    {
        public List<Album> albums = new List<Album>(){
            new Album { AlbumId = 1, Title = "唱片1", AlbumArtUrl = "~/AImages/timg.jpg" },
            new Album { AlbumId = 2, Title = "唱片2", AlbumArtUrl = "~/AImages/timg.jpg" },
            new Album { AlbumId = 3, Title = "唱片3", AlbumArtUrl = "~/AImages/timg.jpg" }
        };
        public ActionResult Lists() {
            List<Album> albums = new List<Album>();
            for (int i = 0; i < 10; i++) {
                albums.Add(new Album { Title = "Product" + i });
            }
            return View(albums);
        }
        public ActionResult Details(int id) {
           
                return View(albums[id-1]);
        }

        public ActionResult Edit() {
            return View();
        }
        public ActionResult Footer() {
            return View();
        }

        public ActionResult AlbumTotal(string total) {
            ViewBag.Message =total;
            return PartialView();
        }

    }
}
