using Entities;
using Erp.BLL;
using Erp.IBLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;

namespace webERP.Controllers
{
    public class BaseController : Controller
    {
        public IActionInfoService _actionInfoService = new ActionInfoService();
        public IUserService _userInfoService = new UserService();
        public User CurrentUserInfo { get; set; }
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);
            CurrentUserInfo = Session["User"] as User;
            if (CurrentUserInfo == null) {
                Response.Redirect("/Account/Login");
                return;
            }
            if (CurrentUserInfo.UName == "admin") {
                return;
            }
            #region 检验用户是否有访问该地址的权利
            string requestUrl = filterContext.HttpContext.Request.Path;
            string requestType = filterContext.HttpContext.Request.RequestType;
            //和权限表对比，如果取出来则通过请求，否则不通过
            //取出当前权限的数据
            var currentAction = _actionInfoService.LoadEntities(c => c.RequestUrl.Equals(requestUrl, StringComparison.InvariantCultureIgnoreCase) && c.RequestHttpType.Equals(requestType)).FirstOrDefault();
            if (currentAction == null) {
                EndRequest();
            }
            //去用户权限表里面查询有没有数据
            var userCurrent = _userInfoService.LoadEntities(u => u.Id == CurrentUserInfo.Id).FirstOrDefault();
            var temp = (from r in userCurrent.R_User_ActionInfo
                        where r.ActionInfoId == currentAction.Id
                        select r).FirstOrDefault();
            if(temp!=null){
                if (temp.HasPermission)
                {
                    return;
                }
                else {
                    EndRequest();
                }
            }
            //UserInfo->ActionGroup_>ActionInfo
            var groups = from n in userCurrent.ActionGroup
                         select n;
            bool isPass = (from g in groups
                           from a in g.ActionInfo
                           select a.Id).Contains(currentAction.Id);
            if (isPass) {
                return;
            }
            //
            var UserRoles = from r in userCurrent.R_User_Role
                            select r.Role;
            var Rolesaction = (from r in UserRoles
                               from a in r.ActionInfo
                               select a.Id);
            if (Rolesaction.Contains(currentAction.Id)) {
                return;
            }
            var RoleGroupAction = from r in UserRoles
                                  from g in r.ActionGroup
                                  select g;
            var groupActions = from r in RoleGroupAction
                               from g in r.ActionInfo
                               select g.Id;
            if (groupActions.Contains(currentAction.Id)) {
                return;
            }
            #endregion
        }
        public void EndRequest() {
            Response.Redirect("/Error.html");
        }
    }
}
