using Entities;
using Erp.BLL;
using Erp.IBLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Mvc;
using webERP.Bll;
using webERP.Models;

namespace webERP.Controllers
{
    public class AccountController : Controller
    {
        IUserService _iUserService = new UserService();

        public ActionResult Login() {
            return View();
        }

        [HttpPost]
        public ActionResult Login(User userInfo) {
            if (userInfo.UName != null) {
                Response.Cookies["UName"].Value = userInfo.UName;
                Response.Cookies["UName"].Expires = DateTime.Now.AddDays(7);
            }
            User user = _iUserService.CheckUserLogin(userInfo);
            if (user != null)
            {
                Session["User"] = user;
               return Redirect("/Home/ErpDefault");
                
            }
            else {
                return Content("用户名密码错误，请您检查");
            }

        }

        public ActionResult Register() {
            return View();
        }

        [HttpPost]
        public ActionResult Register(User user) {
            if (ModelState.IsValid)
            {
                //users.Add(user);
                return RedirectToAction("Login");
            }
            return View();
        }
    }
}
