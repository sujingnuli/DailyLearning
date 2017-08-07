using Entities;
using Erp.IBLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Erp.BLL
{
    public partial class RoleService:BaseService<Role>,IRoleService
    {
        public IQueryable<Role> LoadRoleInfo(GetModelQuery roleInfo)
        {
            //查询出所有的数据
            var temp = _dbSession.RoleInfoRepository.LoadEntities(c => true);
            //判断角色名称
            if (!string.IsNullOrEmpty(roleInfo.RoleName)) {
                temp = temp.Where<Role>(c =>c.RoleName.Contains(roleInfo.RoleName));
            }
            //判断角色名称是否赋值
            if (roleInfo.RoleType != "-1" && !string.IsNullOrEmpty(roleInfo.RoleType)) {
                temp = temp.Where<Role>(c => c.RoleType.Equals(Convert.ToInt16(roleInfo.RoleType)));
            }
            //获取总数
            roleInfo.total = temp.Count();

            //获取总数返回
            return temp.Skip<Role>(roleInfo.pageSize * (roleInfo.pageIndex - 1)).Take(roleInfo.pageSize);

        }


        public int DeleteUserRoleInfo(List<int> deleteIdList)
        {
            foreach (var tId in deleteIdList) {
                _dbSession.RoleInfoRepository.DeleteEntites(new Role { Id = tId });
            }
            return _dbSession.SaveChanges();
        }
    }
}
