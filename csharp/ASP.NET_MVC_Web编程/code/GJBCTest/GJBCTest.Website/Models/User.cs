using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GJBCTest.Website.Models
{
    public class User
    {
        [Remote("CheckUserName","Account")]
        public string userName { get; set; }
    }
}