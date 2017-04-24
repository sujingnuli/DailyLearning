using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace TestCons.test.chp12
{
    public class FakeQuery<T>:IQueryable<T>
    {
        public Expression Expression { get; private set; }
        public IQueryProvider Provider { get; private set; }
        public Type ElementType { get; private set; }

        internal FakeQuery(IQueryProvider provider, Expression expression) {
            this.Expression = expression;
            this.Provider = provider;
            this.ElementType = typeof(T);
        }

        internal FakeQuery() : this(new FakeQueryProvider(), null) {
            Expression = Expression.Constant(this);
        }

        public IEnumerator<T> GetEnumerator() {
            return Enumerable.Empty<T>().GetEnumerator();
        }
         IEnumerator IEnumerable.GetEnumerator() {
            return Enumerable.Empty<T>().GetEnumerator();
        }
        public override string ToString()
        {
            return "FakeQuery";
        }
    }
}
