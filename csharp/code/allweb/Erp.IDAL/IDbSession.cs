using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Erp.IDAL
{
    public partial interface IDbSession
    {
        IActionGroupRespository ActionGroupRespository { get;  }

        IActionInfoRespository ActionInfoRepository { get;  }

        IRoleRepository RoleInfoRepository { get; }

        IUserInfoRepository UserInfoRepository { get; }

        IR_User_RoleRepository R_User_RoleRepository { get; }

        IR_User_ActionInfoRepository R_User_ActionInfoRespository { get; }

        #region
        int SaveChanges();

        int ExecuteSql(string strSql, DbParameter[] parameters);
        #endregion
    }

}
