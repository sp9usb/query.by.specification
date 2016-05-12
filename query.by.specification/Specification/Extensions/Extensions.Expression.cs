using System;
using System.Linq;
using System.Linq.Expressions;

namespace query.@by.specification.Specification.Extensions
{
    public static class ExpressionExtensions
    {
        public static Expression<Func<T, bool>> Invert<T>(this Expression<Func<T, bool>> original)
        {
            return Expression.Lambda<Func<T, bool>>(Expression.Not(original.Body), original.Parameters.Single());
        }
    }
}