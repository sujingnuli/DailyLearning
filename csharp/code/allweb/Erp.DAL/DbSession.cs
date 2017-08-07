using Erp.IDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Erp.DAL
{
    public class DbSession:IDbSession
    {
        public IActionGroupRespository ActionGroupRespository
        {
            get { return new ActionGroupRepository(); }
        }

        public IActionInfoRespository ActionInfoRepository
        {
            get { return new ActionInfoRepository(); }
        }

        public IRoleRepository RoleInfoRepository
        {
            get { return new RoleRepository(); }
        }

        public IUserInfoRepository UserInfoRepository
        {
            get { return new UserRepository(); }
        }

        public IR_User_RoleRepository R_User_RoleRepository
        {
            get { return new R_User_RoleRepository(); }
        }

        public IR_User_ActionInfoRepository R_User_ActionInfoRespository
        {
            get { return  new R_User_ActionInfoRepository(); }
        }

        public int SaveChanges()
        {
            return EFContextFactory.GetCurrentDbContext().SaveChanges();
        }

        public int ExecuteSql(string strSql, System.Data.Common.DbParameter[] parameters)
        {
            throw new NotImplementedException();
        }
    }
}
