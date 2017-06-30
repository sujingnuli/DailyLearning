using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EBuy.Controllers
{
    public class Test2Controller : baseController
    {
        public ActionResult test1(Exception ex) {
            Console.WriteLine(ex.Message);
            return View();
        }
    }
}
