using Entities;
using Erp.BLL;
using Erp.IBLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace webERP.Controllers
{
    public class HomeController : BaseController
    {
        //
        // GET: /Home/
        IUserService _iUserService = new UserService();
        public ActionResult Index()
        {
            User user = Session["User"] as User;
            if (user != null) {
                ViewBag.UName = user.UName;
            }
            return View();
        }
        public ActionResult ErpDefault()
        {
            User uInfo = Session["User"] as User;
            if (uInfo != null) {
                ViewBag.UName = uInfo.UName;
            }
            return View();
        }
        public ActionResult LoadMenuData() {
            var data = _userInfoService.LoadMenuData(CurrentUserInfo.Id);
            return Json(data, JsonRequestBehavior.AllowGet);
        }
    }
}
