using Entities;
using Erp.IBLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Erp.BLL
{
    public partial class ActionGroupService : BaseService<ActionGroup>, IActionGroupService {
        public override void SetCurrentRepository()
        {
            CurrentRepository = _dbSession.ActionGroupRespository;
        }
    }
    public partial class ActionInfoService : BaseService<ActionInfo>, IActionInfoService {
        public override void SetCurrentRepository()
        {
            CurrentRepository = _dbSession.ActionInfoRepository;
        }
    }
    public partial class RoleService : BaseService<Role>, IRoleService {
        public override void SetCurrentRepository()
        {
            CurrentRepository = _dbSession.RoleInfoRepository;
        }
    }
    public partial class UserService : BaseService<User>, IUserService {
        public override void SetCurrentRepository()
        {
            CurrentRepository = _dbSession.UserInfoRepository;
        }
    }
    public partial class R_User_RoleService : BaseService<R_User_Role>, IR_User_RoleService {
        public override void SetCurrentRepository()
        {
            CurrentRepository = _dbSession.R_User_RoleRepository;
        }
    }
    public partial class R_User_ActionInfoService : BaseService<R_User_ActionInfo>, IR_User_ActionInfoService {
        public override void SetCurrentRepository()
        {
            CurrentRepository = _dbSession.R_User_ActionInfoRespository;
        }
    }
}
