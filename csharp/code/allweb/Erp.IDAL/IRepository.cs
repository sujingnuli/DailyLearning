using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Erp.IDAL
{
    public partial interface IActionGroupRespository:IBaseRepository<ActionGroup>
    {

    }
    public partial interface IActionInfoRespository : IBaseRepository<ActionInfo> { 
    
    }
    public partial interface IRoleRepository : IBaseRepository<Role> { 
        
    }
    public partial interface IUserInfoRepository : IBaseRepository<User> { 
        
    }
    public partial interface IR_User_RoleRepository : IBaseRepository<R_User_Role> { 
    
    }
    public partial interface IR_User_ActionInfoRepository : IBaseRepository<R_User_ActionInfo> { 
        
    }
}
