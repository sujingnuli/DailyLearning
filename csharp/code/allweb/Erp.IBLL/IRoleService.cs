using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Erp.IBLL
{
     public partial interface IRoleService:IBaseService<Role>
    {
        IQueryable<Role> LoadRoleInfo(GetModelQuery roleInfo);
        int DeleteUserRoleInfo(List<int> deleteIdList);
    }
}
