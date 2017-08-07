using Erp.IDAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Erp.DAL
{
    public partial class BaseRepository<T> where T:class
    {
        private DbContext db = EFContextFactory.GetCurrentDbContext();

        public T AddEntities(T entity)
        {
            db.Entry<T>(entity).State = EntityState.Added;
            return entity;
        }

        public bool UpdateEntities(T entity)
        {
            try
            {
                db.Set<T>().Attach(entity);
            }catch(Exception e){
                db.Entry(entity).CurrentValues.SetValues(entity);
            }
            
            db.Entry<T>(entity).State = EntityState.Modified;
            return true;
        }

        public bool DeleteEntites(T entity)
        {
            db.Set<T>().Attach(entity);
            db.Entry<T>(entity).State = EntityState.Deleted;
            return true;
        }

        public IQueryable<T> LoadEntities(Func<T, bool> whereLambda)
        {
            return db.Set<T>().Where<T>(whereLambda).AsQueryable();
        }

        public IQueryable<T> LoadPagerEntities<S>(int pageSize, int pageIndex, out int total, Func<T, bool> whereLambda, bool isAsc, Func<T, S> orderLambda)
        {
            var tempData = db.Set<T>().Where<T>(whereLambda);
            total = tempData.Count();
            //排序获取当前页的数据
            if (isAsc)
            {
                tempData = tempData.OrderBy<T, S>(orderLambda).
                    Skip<T>(pageSize * (pageIndex - 1)).Take<T>(pageSize).AsQueryable();
            }
            else {
                tempData = tempData.OrderByDescending<T, S>(orderLambda).
                    Skip<T>(pageSize*(pageIndex - 1)).Take<T>(pageSize).AsQueryable();
            }
            return tempData.AsQueryable();
        }
    }
}
