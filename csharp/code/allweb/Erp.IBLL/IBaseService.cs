using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Erp.IBLL
{
    public partial  interface IBaseService<T> where T:class,new()
    {
        T AddEntities(T entity);

        bool UpdateEntites(T entity);

        bool DeleteEntities(T entity);

        //查询
        IQueryable<T> LoadEntities(Func<T, bool> wherelambda);

        IQueryable<T> LoadPagerEntities<S>(int pageSize, int pageIndex, out int total, Func<T, bool> whereLambda,
            bool isAsc, Func<T, S> orderByLambda);

    }
}
