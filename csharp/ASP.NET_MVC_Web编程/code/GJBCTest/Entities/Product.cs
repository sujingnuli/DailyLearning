using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GJBCTest.WebApi.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Namge { get; set; }
        public decimal Price { get; set; }
        public int UnitsInStock { get; set; }
    }
}