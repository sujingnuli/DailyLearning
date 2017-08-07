using Erp.IDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace Erp.DAL
{
    public class DbSessionFactory
    {
        /// <summary>
        /// 帮助我们返回当前线程内的数据上下文，如果当前线程内没有上下文，就创建一个上下文。并保证该实例是唯一的
        /// 提高效率，在线程中，、共用一个DbSession对象
        /// CallContext ,是能保证数据线程内唯一的容器。在CallContext内部查找是否有DbSession对象。
        /// </summary>
        /// <returns></returns>
        public static IDbSession GetCurrentDbSession() {
            IDbSession _dbSession = CallContext.GetData("DbSession") as IDbSession;

            if (_dbSession == null) {
                _dbSession = new DbSession();
                CallContext.SetData("DbSession", _dbSession);
            }
            return _dbSession;
        }
    }
}
