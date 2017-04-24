using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace TestCons.test.chp12
{
    public  class FakeQueryProvider:IQueryProvider
    {
        public IQueryable<T> CreateQuery<T>(Expression expression) {
            return new FakeQuery<T>(this, expression);
        }
        public IQueryable CreateQuery(Expression expression) {
            Type queryType = typeof(FakeQuery<>).MakeGenericType(expression.Type);
            object[] cons = new object[] { this, expression };
            return (IQueryable)Activator.CreateInstance(queryType, cons);
        }

        public T Execute<T>(Expression expression) {
            return default(T);
        }
        public object Execute(Expression expression) {
          
            return null;
        }
    }
}
