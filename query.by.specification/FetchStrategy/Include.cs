using System;
using System.Linq.Expressions;

namespace query.@by.specification.FetchStrategy
{
    public class Include<T>
    {
        public Include(Expression<Func<T, object>> expression)
        {
            Expression = expression;
        }

        public Expression<Func<T, object>> Expression { get; set; }
    }
}