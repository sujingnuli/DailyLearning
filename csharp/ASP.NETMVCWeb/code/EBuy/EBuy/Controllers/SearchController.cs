using Ebuy.Core.Inter;
using EBuy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EBuy.Controllers
{
    public class SearchController : Controller
    {
        private ISearchProvider searchProvider;
        public SearchController(ISearchProvider provider) {
            this.searchProvider = provider;
        }

        public ActionResult SearchForProducts(string search) {
            List<Product> products = searchProvider.Search<Product>(search);
            return View(products);
        }
       
      
    }
}
