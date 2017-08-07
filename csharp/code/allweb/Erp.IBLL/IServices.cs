using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Erp.IBLL
{
    public partial interface IActionGroupService : IBaseService<ActionGroup> { 
        
    }
    public partial interface IActionInfoService : IBaseService<ActionInfo> { 
        
    }
    public partial interface IRoleService : IBaseService<Role> { 
    
    }
    public partial interface IUserService : IBaseService<User> { 
        
    }
    public partial interface IR_User_RoleService : IBaseService<R_User_Role> { 
    
    }
    public partial interface IR_User_ActionInfoService : IBaseService<R_User_ActionInfo> { 
        
    }
}
