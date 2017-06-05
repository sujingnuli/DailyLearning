using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ebuy.Common.Extensions
{
    public static class CollectionExtensions
    {
        /// <summary>
        /// 分页查询，IEnumerable
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public static IEnumerable<T> Page<T>(this IEnumerable<T> source, int pageIndex, int pageSize) {
            Contract.Requires(pageIndex >= 0, "Page size cannot be negative");
            Contract.Requires(pageSize > 0, "Page size cannot be negative");
            int skip = pageIndex * pageSize;
            if (skip > 0) {
                source = source.Skip(skip);
            }
            source = source.Take(pageSize);
            return source;
        }
        /// <summary>
        /// 分页查询，IQueryable
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <param name="pageIndex"></param>
        /// <param name="PageSize"></param>
        /// <returns></returns>
        public static IQueryable<T> Page<T>(this IQueryable<T> source, int pageIndex, int pageSize) {
            Contract.Requires(pageIndex >= 0, "Page Index cannot be negative");
            Contract.Requires(pageSize > 0, "Page size cannot be negative");

            int skip = pageIndex * pageSize;
            if (skip > 0) {
                source.Skip(skip);
            }
            source = source.Take(pageSize);
            return source;
        }
    }
}
