using Ebuy.Common.DataAccess;
using Ebuy.Common.Entities;
using Ebuy.Common.Inter;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ebuy.Common.Clz
{
    public class Repository:IRepository
    {
        private readonly DataContext _context;
        private readonly bool _isSharedContext;

        public Repository(DataContext context, bool isSharedContext = true) {
            Contract.Requires(context != null);
            _context = context;
            _isSharedContext = isSharedContext;
        }


        public void Add<T>(T instance) where T : class,IEntity
        {
            Contract.Requires(instance != null);
            _context.Set<T>().Add(instance);
            if (_isSharedContext == false) {
                _context.SaveChanges();
            }
        }

        public void Add<T>(IEnumerable<T> instances) where T : class,IEntity
        {
            Contract.Requires(instances != null);
            foreach (var instance in instances) {
                Add(instance);
            }
        }

        public IQueryable<T> All<T>(params string[] includePaths) where T : class,IEntity
        {
            return Query<T>(x => true, includePaths);
        }

        public void Delete<T>(object key) where T : class,IEntity
        {
            Contract.Requires(key != null);
            T instance = Single<T>(key);
            Delete(instance);
        }

        public void Delete<T>(T instance) where T : class,IEntity
        {
            Contract.Requires(instance != null);
            if (instance != null) {
                _context.Set<T>().Remove(instance);
            }
        }

        public void Delete<T>(System.Linq.Expressions.Expression<Func<T, bool>> predicate) where T : class,IEntity
        {
            Contract.Requires(predicate != null);
            T entity = Single(predicate);
            Delete(entity);
        }

        public T Single<T>(object key) where T : class,IEntity
        {
            Contract.Requires(key != null);
            var instace = _context.Set<T>().Find(key);
            return instace;
        }

        public T Single<T>(System.Linq.Expressions.Expression<Func<T, bool>> predicate, params string[] includePaths) where T : class,IEntity
        {
            Contract.Requires(predicate != null);
            var instance = GetSetWithIncludedPaths<T>(includePaths).SingleOrDefault(predicate);
            return instance;
        }

        public IQueryable<T> Query<T>(System.Linq.Expressions.Expression<Func<T, bool>> predicate, params string[] includePaths) where T : class,IEntity
        {
            Contract.Requires(predicate != null);
            var items = GetSetWithIncludedPaths<T>(includePaths);
            if (predicate != null) {
                return items.Where(predicate);
            }
            return items;


        }

        public void Dispose()
        {
            if (_isSharedContext || _context == null) {
                _context.Dispose();
            }
        }
        private DbQuery<T> GetSetWithIncludedPaths<T>(IEnumerable<string> includedPaths) where T : class,IEntity {
            DbQuery<T> items = _context.Set<T>();
            foreach (var path in includedPaths ?? Enumerable.Empty<string>()) {
                items = items.Include(path);
            }
            return items;
        }
    }
}
