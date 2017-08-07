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
    public class RoleController : BaseController
    {
        IRoleService _roleService = new RoleService();
        public ActionResult Index() {
            return View();
        }
        /// <summary>
        /// 实现对用户角色的绑定
        /// </summary>
        /// <returns></returns>
        public ActionResult GetAllUserRoleInfo() {
            int pageIndex = Request["page"] == null ? 1 : Convert.ToInt32(Request["page"]);
            int pageSize = Request["rows"] == null ? 10 : Convert.ToInt32(Request["rows"]);

            string RoleName = Request["RoleName"];
            string RoleType = Request["RoleType"];

            GetModelQuery roleInfo = new GetModelQuery();
            roleInfo.pageIndex = pageIndex;
            roleInfo.pageSize = pageSize;
            roleInfo.RoleName = RoleName;
            roleInfo.RoleType = RoleType;

            //获取所有的总数输入
            var data = from n in _roleService.LoadRoleInfo(roleInfo)
                       select new { n.Id, n.DelFlag, n.RoleName, n.RoleType, n.SubTime };
            var jsonResult = new { total = roleInfo.total, rows = data };
            return Json(jsonResult, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// 实现对用户角色的添加信息
        /// </summary>
        /// <param name="role"></param>
        /// <returns></returns>
        public ActionResult AddUserRoleInfo(Role role) {
            role.DelFlag = (short)DelFlagEnum.Normal;
            role.SubTime = DateTime.Now;
            _roleService.AddEntities(role);
            return Content("OK");
        }
        /// <summary>
        ///删除用户角色信息
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public ActionResult DeleteUserRoleInfo(string Id) {
            if (string.IsNullOrEmpty(Id)) {
                return Content("请选择要删除的数据");
            }
            var deleteId = Id.Split(',');
            List<int> deleteIdList = new List<int> { };
            foreach (var dId in deleteId) {
                deleteIdList.Add(Convert.ToInt32(dId));
            }
            if (_roleService.DeleteUserRoleInfo(deleteIdList) > 0) {
                return Content("OK");
            }
            return Content("删除失败，请您检查");
        }
        /// <summary>
        /// 绑定修改数据信息
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public ActionResult BindUserRoleInfo(int Id) {
            Role role = _roleService.LoadEntities(u => u.Id == Id).FirstOrDefault();
            return Json(role, JsonRequestBehavior.AllowGet);
        }
        public ActionResult UpdateUserRoleInfo(Role role) {
            var editRole = _roleService.LoadEntities(u => u.Id == role.Id).FirstOrDefault();
            editRole.RoleName = role.RoleName;
            editRole.RoleType = role.RoleType;
            _roleService.UpdateEntites(role);
            return Content("OK");
        }
    }
}
