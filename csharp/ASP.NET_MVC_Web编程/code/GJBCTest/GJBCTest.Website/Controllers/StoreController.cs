using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GJBCTest.Website.Controllers
{
    public class StoreController : Controller
    {
        //
        // GET: /Store/

        public string Index()
        {
            return "Hello form store.Index()";
        }

        public string Browse(string genre) {
            return genre;
        }

        public string Details(int id) {
            return id+"";
        }

    }
}
