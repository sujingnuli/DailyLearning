using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EBuy.Controllers
{
    public class Test2Controller : baseController
    {
        public ActionResult test1() {
            throw new Exception("just a Exception");
        }
    }
}
