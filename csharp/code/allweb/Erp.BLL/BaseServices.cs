using Erp.DAL;
using Erp.IBLL;
using Erp.IDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Erp.BLL
{
    public abstract class BaseService<T> where T:class,new()
    {
        public IBaseRepository<T> CurrentRepository{get;set;}
        //为了单一职能的原则，将线程内获取唯一实例的DbSession放到工厂里去
        public IDbSession _dbSession = DbSessionFactory.GetCurrentDbSession();

        public BaseService(){
            SetCurrentRepository();
        }
        public abstract void SetCurrentRepository();

        public T AddEntities(T entity)
        {
            var addentity = CurrentRepository.AddEntities(entity);
            _dbSession.SaveChanges();
            return addentity;
        }

        public bool UpdateEntites(T entity)
        {
            var updateEntity = CurrentRepository.UpdateEntities(entity);
            _dbSession.SaveChanges();
            return updateEntity;
        }

        public bool DeleteEntities(T entity)
        {
            var deleteEntity = CurrentRepository.DeleteEntites(entity);
            _dbSession.SaveChanges();
            return deleteEntity;
        }

        public IQueryable<T> LoadEntities(Func<T, bool> wherelambda)
        {
            return CurrentRepository.LoadEntities(wherelambda);
        }

        public IQueryable<T> LoadPagerEntities<S>(int pageSize, int pageIndex, out int total, Func<T, bool> whereLambda, bool isAsc, Func<T, S> orderByLambda)
        {
            return CurrentRepository.LoadPagerEntities(pageSize, pageIndex, out total, whereLambda, isAsc, orderByLambda);
        }
    }
}
