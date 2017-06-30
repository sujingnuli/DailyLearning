﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GJBCTest.Website.Models;

namespace GJBCTest.Website.Controllers
{
    public class HomeController : Controller
    {
        private MusicStoreDBContext db = new MusicStoreDBContext();
       
        public ActionResult Index() {
            return View();
        }

        public ActionResult Search(string q) {
            var albums = db.Albums.Include("Artist").Where(a => a.Title.Contains(q)).Take(10);
            return View(albums);
        }
        public ActionResult Genres() {
            var genres = db.Genres;
            return View(genres);
        }
    }
}