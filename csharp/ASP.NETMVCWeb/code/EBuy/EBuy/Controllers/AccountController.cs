using DotNetOpenAuth.AspNet;
using EBuy.Filters;
using EBuy.Models;
using Microsoft.Web.WebPages.OAuth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using WebMatrix.WebData;

namespace EBuy.Controllers
{

    [Authorize]
    [InitializeSimpleMembership]
    public class AccountController : Controller
    {
        /// <summary>
        /// Get /Account/Login
        /// </summary>
        /// <param name="returnUrl"></param>
        /// <returns></returns>
        [AllowAnonymous]
        public ActionResult Login(string returnUrl) {
            return ContextDependentView();
            //ViewBag.ReturnUrl = returnUrl;
            //return View();
        }
        private ActionResult ContextDependentView() {
            string actionName = ControllerContext.RouteData.GetRequiredString("action");
            if (Request.QueryString["content"] != null)
            {
                ViewBag.Title = "Json" + actionName;
                return PartialView();
            }
            else {
                ViewBag.FormAction = actionName;
                return View();
            }
        }
       
        [HttpPost]
        [AllowAnonymous]
        public ActionResult Login(LoginModel model, string returnUrl) {
            if (ModelState.IsValid) {
                if (Membership.ValidateUser(model.UserName, model.Password))
                {
                    FormsAuthentication.SetAuthCookie(model.UserName, model.RememberMe);
                    if (Url.IsLocalUrl(returnUrl))
                    {
                        return Redirect(returnUrl);
                    }
                    else {
                        return RedirectToAction("Index", "Search");
                    }
                }
                else {
                    ModelState.AddModelError("", "The user name or password provided is incorrect");
                }
            }
            return View(model);
        }

        [HttpPost]
        [AllowAnonymous]
        public JsonResult JsonLogin(LoginModel model, string returnUrl) {
            if (ModelState.IsValid) {
                if (Membership.ValidateUser(model.UserName, model.Password))
                {
                    FormsAuthentication.SetAuthCookie(model.UserName, model.RememberMe);
                    return Json(new { success = true, redirect = returnUrl });
                }
                else {
                    ModelState.AddModelError("", "The user name or password provided is incorrect");
                }
            }
            return Json(new { success=false });
        }

        [HttpPost]
        [AllowAnonymous]
        public JsonResult JsonRegister(RegisterModel model) {
            if (ModelState.IsValid) {
                MembershipCreateStatus createStatus;
                Membership.CreateUser(model.UserName, model.Password,null,null,null, isApproved: true, status: out createStatus);
                if (createStatus == MembershipCreateStatus.Success)
                {
                    FormsAuthentication.SetAuthCookie(model.UserName, createPersistentCookie: false);
                    return Json(new { success = true });
                }
                else {
                    ModelState.AddModelError("", ErrorCodeToString(createStatus));
                }
            }
            return Json(new { success = false });
        }

        //[HttpPost]
        //[AllowAnonymous]
        //[ValidateAntiForgeryToken]
        //public ActionResult Login(LoginModel model, string returnUrl) {
        //    if (ModelState.IsValid && WebSecurity.Login(model.UserName, model.Password, persistCookie: model.RememberMe)) {
        //        return RedirectToLocal(returnUrl);
        //    }
        //    bool t = WebSecurity.Login(model.UserName, model.Password, persistCookie: model.RememberMe);
        //    ModelState.AddModelError("", "The user name or password provided is incorrect.");
        //    return View(model);
        //}

        [AllowAnonymous]
        [ChildActionOnly]
        public ActionResult ExternalLoginsList(string returnUrl) {
            ViewBag.ReturnUrl = returnUrl;
            return PartialView("_ExternalLoginsListPartial", OAuthWebSecurity.RegisteredClientData);
        }

        public ActionResult ExternalLogin(string provider,string returnUrl) {
            return new ExternalLoginResult(provider, Url.Action("ExternalLoginCallback", new { ReturnUrl = returnUrl }));
        }
        //GET: Account/ExternalLoginCallback
        [AllowAnonymous]
        public ActionResult ExternalLoginCallback(string returnUrl) {
            AuthenticationResult result = OAuthWebSecurity.VerifyAuthentication(Url.Action("ExternalCallback", new { ReturnUrl = returnUrl }));
            if (!result.IsSuccessful) {
                return RedirectToAction("ExternalLoginFailure");
            }
            if (OAuthWebSecurity.Login(result.Provider, result.ProviderUserId, createPersistentCookie: false)) {
                return RedirectToLocal(returnUrl);
            }
            if (User.Identity.IsAuthenticated)
            {
                OAuthWebSecurity.CreateOrUpdateAccount(result.Provider, result.ProviderUserId, User.Identity.Name);
                return RedirectToLocal(returnUrl);
            }
            else {
                string loginData = OAuthWebSecurity.SerializeProviderUserId(result.Provider, result.ProviderUserId);
                ViewBag.ProviderDisplayName = OAuthWebSecurity.GetOAuthClientData(result.Provider).DisplayName;
                ViewBag.ReturnUrl = returnUrl;
                return View("ExternalLoginConfirmation", new RegisterExternalLoginModel { UserName = result.UserName, ExternalLoginData = loginData });
            }
        }
        [AllowAnonymous]
        public ActionResult ExternalLoginFailure() {
            return View();
        }

        //Get  Account/Register,分为AJAX请求和标准请求
        [AllowAnonymous]
        public ActionResult Register() {
            return ContextDependentView();
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult Register(RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                //尝试注册新用户
                MembershipCreateStatus createStatus;
                Membership.CreateUser(model.UserName, model.Password, null, null, null, true, null, out createStatus);
                if (createStatus == MembershipCreateStatus.Success)
                {
                    FormsAuthentication.SetAuthCookie(model.UserName, createPersistentCookie: false);
                    return RedirectToAction("Index", "Search");
                }
                else
                {
                    ModelState.AddModelError("", ErrorCodeToString(createStatus));
                }
            }
            return View(model);
        }
        //[HttpPost]
        //[AllowAnonymous]
        //public ActionResult Register(RegisterModel model) {
        //    if (ModelState.IsValid) {
        //        try
        //        {
        //            WebSecurity.CreateUserAndAccount(model.UserName, model.Password);
        //            WebSecurity.Login(model.UserName, model.Password);
        //            return RedirectToAction("Index", "Search");
        //        }
        //        catch (MembershipCreateUserException e) {
        //            ModelState.AddModelError("", ErrorCodeToString(e.StatusCode));
        //        }
        //    }
        //    return View(model);
        //}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LogOff() {
            //WebSecurity.Logout();

            FormsAuthentication.SetAuthCookie(null, false);
           
            return RedirectToAction("Login");
        }

        //Get manager
        
        public ActionResult Manager(ManageMessageId? message) {
            ViewBag.StatusMessage = message == ManageMessageId.ChangePasswordSuccess ? "Your password has been changed."
                : message == ManageMessageId.SetPasswordSuccess ? "Your password has been set." :
                message == ManageMessageId.RemoveLoginSuccess ? "The external login was removed." : "";
            ViewBag.HasLocalPassword = OAuthWebSecurity.HasLocalAccount(WebSecurity.GetUserId(User.Identity.Name));
            ViewBag.ReturnUrl = Url.Action("Manage");
            return View();
        }

        //Get ChangePassword
        public ActionResult ChangePassword() {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ChangePassword(ChangePasswordModel model) {
            if (ModelState.IsValid) {
                bool changePasswordSuccessded;
                try
                {
                    MembershipUser currentUser = Membership.GetUser(User.Identity.Name, userIsOnline: true);
                    changePasswordSuccessded = currentUser.ChangePassword(model.OldPassword, model.NewPassword);
                }
                catch (Exception e) {
                    changePasswordSuccessded = false;
                }
                if (changePasswordSuccessded)
                {
                    return RedirectToAction("ChangePasswordSuccess");
                }
                else {
                    ModelState.AddModelError("", "The current password is uncorrect or the new password is invalid");

                }
            }
            return View(model);
        }

        public ActionResult ChangePasswordSuccess() {
            return View();
        }
        #region Helpers
        internal class ExternalLoginResult : ActionResult {
            public string Provider { get; set; }
            public string ReturnUrl { get; set; }
            public ExternalLoginResult(string provider, string returnUrl) {
                Provider = provider;
                ReturnUrl = returnUrl;
            }
            public override void ExecuteResult(ControllerContext context)
            {
                //通过将用户引导至外部网站，请求提供程序启动身份验证，验证成功后，指示提供程序将用户重定向到returnUrl
                OAuthWebSecurity.RequestAuthentication(Provider, ReturnUrl);
            }
        }

        public ActionResult RedirectToLocal(string returnUrl) {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            else {
                return RedirectToAction("Index", "Search");
            }
        }

        private static string ErrorCodeToString(MembershipCreateStatus createStatus) {
            switch (createStatus) { 
                case MembershipCreateStatus.DuplicateUserName:
                    return "User name already exists.Please enter a different user name";
                case MembershipCreateStatus.DuplicateEmail:
                    return "A user name for that e-mail address already exists.Please enter a different e-mail address";
                default:
                    return "An unknow error occurred. Please verify your entry and try again.If the problem persists,please contact your system administrator.";
            }
        }

        public enum ManageMessageId { 
            ChangePasswordSuccess,
            SetPasswordSuccess,
            RemoveLoginSuccess
        }
        #endregion


    }
}
