using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GJBCTest.Website.Models
{
    public class ShoppingCartSummaryViewModel
    {
        public IEnumerable<Album> albums { get; set; }
        public decimal CartTotal { get; set; }
        public string Message { get; set; }
    }
}