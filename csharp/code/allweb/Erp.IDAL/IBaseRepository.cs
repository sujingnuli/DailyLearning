using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Erp.IDAL
{
    public interface IBaseRepository<T> where T:class,new()
    {
        T AddEntities(T entity);
        bool UpdateEntities(T entity);
        bool DeleteEntites(T entity);
        IQueryable<T> LoadEntities(Func<T, bool> whereLambda);
        IQueryable<T> LoadPagerEntities<S>(int pageSize, int pageIndex, out int total, Func<T, bool> whereLambda, bool isAsc, Func<T, S> orderLambda);
    }
}
