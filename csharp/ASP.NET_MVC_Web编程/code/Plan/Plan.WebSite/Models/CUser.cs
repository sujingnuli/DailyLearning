using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Plan.WebSite.Models
{
    public class CUser
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string password { get; set; }
        public string verification { get; set; }
    }
}