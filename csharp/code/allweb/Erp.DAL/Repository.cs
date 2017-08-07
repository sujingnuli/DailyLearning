using Entities;
using Erp.IDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Erp.DAL
{
    public partial class ActionGroupRepository : BaseRepository<ActionGroup>, IActionGroupRespository { 
        
    }
    public partial class ActionInfoRepository : BaseRepository<ActionInfo>, IActionInfoRespository { 
        
    }
    public partial class RoleRepository : BaseRepository<Role>, IRoleRepository { 
        
    }
    public partial class UserRepository : BaseRepository<User>, IUserInfoRepository { 
    
    }
    public partial class R_User_RoleRepository : BaseRepository<R_User_Role>, IR_User_RoleRepository { 
        
    }
    public partial class R_User_ActionInfoRepository : BaseRepository<R_User_ActionInfo>, IR_User_ActionInfoRepository { 
        
    }
}
