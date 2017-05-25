using Ebuy.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Ebuy.Core.Inter
{
    public interface IRepository:IDisposable
    {
        void Add<T>(T instance) where T : class,IEntity;
        void Add<T>(IEnumerable<T> instances) where T : class,IEntity;

        IQueryable<T> All<T>(params string[] includePaths) where T : class,IEntity;

        void Delete<T>(object key) where T : class,IEntity;
        void Delete<T>(T instance) where T : class,IEntity;
        void Delete<T>(Expression<Func<T, bool>> predicate) where T : class,IEntity;

        T Single<T>(object key) where T : class,IEntity;
        T Single<T>(Expression<Func<T, bool>> predicate, params string[] includePaths) where T : class,IEntity;
        IQueryable<T> Query<T>(Expression<Func<T, bool>> predicate, params string[] includePaths) where T : class,IEntity;
       
    }
}
