using GJBCTest.Website.Common;
using GJBCTest.Website.Models;
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
        private MusicStoreDBContext db = new MusicStoreDBContext();
        //
        // GET: /Account/
        [AllowAnonymous]
        public ActionResult Login() {
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        public ActionResult Login(User user,string returnUrl) {
            if (ModelState.IsValid) {
                string pwd = MD5Utils.GetMD5_32(user.Password);
                var xuser = db.Users.Single(m => m.UserName.Equals(user.UserName.Trim()));
                if (pwd.Equals(xuser.Password)) {
                    Session["UserId"] = xuser.UserId;
                    Session["UserName"] = xuser.UserName;
                    ViewBag.UserName = xuser.UserName;
                    return RedirectToLocal(returnUrl);
                }
                ModelState.AddModelError("", "用户名或密码错误");
            }
            return View(user);

        }

        public JsonResult CheckUserName(string userName) {
           var result= Membership.FindUsersByName(userName).Count == 0;
           return Json(result, JsonRequestBehavior.AllowGet);
        }
        [AllowAnonymous]
        public ActionResult Register() {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult Register(RegisterModel registerModel) {
            if (ModelState.IsValid) {
                User user = new User();
                user.UserName = registerModel.UserName;
                user.Password = MD5Utils.GetMD5_32(registerModel.Password);
                db.Users.Add(user);
                db.SaveChanges();
                ViewBag.UserName = user.UserName;
                RedirectToAction("Login", new { user,returnUrl="/Store/Index"});
            }
            return View(registerModel);
        }

        public ActionResult RedirectToLocal(string returnUrl) {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            else {
                return RedirectToAction("Index", "Store");
            }

        }

        public ActionResult Logout() {
            Session.Remove("UserId");
            Session.Remove("UserName");
            return RedirectToAction("Login");
        }
    }
}
