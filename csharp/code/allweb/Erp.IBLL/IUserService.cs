using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Erp.IBLL
{
    public partial interface IUserService:IBaseService<User>
    {
        User CheckUserLogin(User user);

        IQueryable<MenuData> LoadMenuData(int userId);

        IQueryable<User> GetAllUserInfos(GetModelQuery queryData);

        int DeleteUserInfo(List<int> DeleteUserInfoId);
    }
}
