using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GJBCTest.Website.Models
{
    public class User
    {
        public virtual int UserId { get; set; }
        [Remote("CheckUserName","Account")]
        public virtual string UserName { get; set; }
        public virtual string Password { get; set; }
        
    }
}