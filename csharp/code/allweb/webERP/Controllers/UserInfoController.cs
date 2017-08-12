using Entities;
using Entities.Enum;
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
    public class UserInfoController : BaseController
    {
        IUserService _userService = new UserService();
        IRoleService _roleService = new RoleService();
        public ActionResult Index() {
            return View();
        }

        /// <summary>
        /// 获取所有用户信息
        /// </summary>
        /// <returns></returns>
        public ActionResult GetAllUserInfos() {
            int pageIndex = Request["pages"] == null ? 1 : Convert.ToInt32(Request["pages"]);
            int pageSize = Request["rows"] == null ? 10 : Convert.ToInt32(Request["rows"]);

            string Name = Request["Name"];
            string Mail = Request["Mail"];

           GetModelQuery userInfo=new GetModelQuery();
           userInfo.pageIndex = pageIndex;
           userInfo.pageSize = pageSize;
           userInfo.Name = Name;
           userInfo.Mail = Mail;
           userInfo.total = 0;

           var data = from n in _userService.GetAllUserInfos(userInfo)
                      select new { n.Id, n.UName, n.Pwd, n.Phone, n.Mail, n.LastModifiedOn, n.SubTime };
           var JsonResult = new { total = userInfo.total, rows = data };
           return Json(JsonResult, JsonRequestBehavior.AllowGet);
        }

        //注册用户
        public ActionResult Regist(User user) {
            user.LastModifiedOn = DateTime.Now;
            user.SubTime = DateTime.Now;
            user.DelFlag = (short)DelFlagEnum.Normal;
            _userService.AddEntities(user);
            return Content("OK");
        }
        //删除用户
        public ActionResult DeleteUserInfo(string deleteUserInfoId, string UName)
        {
            User user = Session["User"] as User;
            var logName = user.UName;

            var UIdsName = UName.Split(',');
            List<string> deleteUName = new List<string>();
            foreach (var Name in UIdsName) {
                deleteUName.Add(Name);
            }
            if (deleteUName.Contains(logName)) {
                return Content("含有正在使用的用户,禁止删除");
            }
            if (string.IsNullOrEmpty(deleteUserInfoId)) {
                return Content("请选择要删除的数据");
            }
            var idsStr = deleteUserInfoId.Split(',');
            List<int> deleteIdList = new List<int>();
            foreach (var id in idsStr) {
                deleteIdList.Add(Convert.ToInt32(id));
            }
            if (_userService.DeleteUserInfo(deleteIdList)>0) {
                return Content("OK");
            }
            return Content("删除失败，请您检查");
        }
        //修改用户信息
        public ActionResult UpdateUserInfo(User user) {
            User editUser = _userService.LoadEntities(u => u.Id == user.Id).FirstOrDefault();
            editUser.UName = user.UName;
            editUser.Pwd = user.Pwd;
            editUser.Phone = user.Phone;
            editUser.Mail = user.Mail;
            _userService.UpdateEntites(editUser);
            return Content("OK");
        }
        //获取Update绑定的用户信息
        public ActionResult GetBindDetails(int Id) {
            User user = _userService.LoadEntities(u => u.Id == Id).FirstOrDefault();
            User user2 = new User { Id = Id, UName = user.UName, Pwd = user.Pwd, Phone = user.Phone, LastModifiedOn = user.LastModifiedOn, SubTime = user.SubTime,Mail=user.Mail };
            return Json(user2, JsonRequestBehavior.AllowGet);
        }
        //设置用户角色
        //Get请求
        public ActionResult SetRole(int Id) {
            var currentUser = _userService.LoadEntities(u => u.Id == Id).FirstOrDefault();
            ViewData.Model = currentUser;
            short deleteNormal = (short)DelFlagEnum.Normal;
            var allRoles = _roleService.LoadEntities(u => u.DelFlag == deleteNormal).ToList();
            ViewBag.AllRoles = allRoles;
            ViewBag.ExtistRoleIds = (from r in currentUser.R_User_Role
                                     select r.RoleId).ToList();
            return View();
        }
    }
}
