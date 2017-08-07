using Entities;
using Entities.Compare;
using Entities.Enum;
using Erp.IBLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Erp.BLL
{
    public partial class UserService:BaseService<User>,IUserService
    {
        public User CheckUserLogin(User user)
        {
            return  _dbSession.UserInfoRepository.LoadEntities(u => u.UName == user.UName && u.Pwd == user.Pwd).FirstOrDefault();
        }

        /// <summary>
        /// 加载所有的菜单数据，显示在菜单上面
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public IQueryable<MenuData> LoadMenuData(int userId)
        {
            var CurrentUser = _dbSession.UserInfoRepository.LoadEntities(c => c.Id == userId).FirstOrDefault();
            if (CurrentUser == null) {
                return null;
            }
            var userRoleList = from r in CurrentUser.R_User_Role
                               select r.Role;
            var groups = from n in userRoleList
                         from g in n.ActionGroup
                         select g;
            short actionType = (short)ActionTypeEnum.MenuItem;
            groups.Distinct(new EntityCompare());

            var menuData = from g in groups
                           select new MenuData
                           {
                               GroupID = g.Id,
                               GroupName = g.GroupName,
                               MenuItems = (from a in g.ActionInfo
                                            where a.ActionType == actionType
                                            select new MenuItem
                                            {
                                                Id = a.Id,
                                                MenuName = a.ActionName,
                                                Url = a.RequestUrl
                                            })
                           };
            return menuData.AsQueryable();
        }


        public IQueryable<User> GetAllUserInfos(GetModelQuery userInfo)
        {
            var temp = _dbSession.UserInfoRepository.LoadEntities(c => true);
            if (!string.IsNullOrEmpty(userInfo.Name)) {
                temp = temp.Where<User>(u => u.UName.Contains(userInfo.Name));
            }
            if (!string.IsNullOrEmpty(userInfo.Mail)) {
                temp = temp.Where<User>(u => u.Mail.Contains(userInfo.Mail));
            }
            userInfo.total = temp.Count();
            return temp.Skip<User>(userInfo.pageSize * (userInfo.pageIndex - 1)).Take(userInfo.pageSize).AsQueryable();
        }


        public int DeleteUserInfo(List<int> DeleteUserInfoId)
        {
            foreach (var Id in DeleteUserInfoId) {
                _dbSession.UserInfoRepository.DeleteEntites(new User() { Id = Id });
            }
            return _dbSession.SaveChanges();
        }
    }
}
