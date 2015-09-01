using System;
using System.Linq;
using System.Linq.Expressions;
using query.@by.specification.Specification.Extensions.Support;

namespace query.@by.specification.Specification.Extensions
{
    internal static class CompositeSpecificationExtensions
    {
        internal static Expression<T> Compose<T>(this Expression<T> left, Expression<T> right, Func<Expression, Expression, Expression> merge)
        {
            // zip parameters (map from parameters of second to parameters of first)
            var map = left.Parameters
                .Select((f, i) => new { f, s = right.Parameters[i] })
                .ToDictionary(p => p.s, p => p.f);

            // replace parameters in the second lambda expression with the parameters in the first
            var secondBody = ParameterRebinder.ReplaceParameters(map, right.Body);

            // create a merged lambda expression with parameters from the first expression
            return Expression.Lambda<T>(merge(left.Body, secondBody), left.Parameters);
        }
    }
}