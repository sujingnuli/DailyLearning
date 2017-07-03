using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace GJBCTest.Website.Controllers
{
    public class AccountController : Controller
    {
        //
        // GET: /Account/

        public JsonResult CheckUserName(string userName) {
           var result= Membership.FindUsersByName(userName).Count == 0;
           return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}
