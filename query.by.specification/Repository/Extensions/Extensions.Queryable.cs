using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using query.@by.specification.Specification;
using yesmarket.Linq.Expressions;

namespace query.@by.specification.Repository.Extensions
{
    internal static class QueryableExtensions
    {
        internal static IQueryable<T> Fetch<T>(this IQueryable<T> value, IEnumerable<IInclude<T>> includes)
        {
            var includes1 = includes as IInclude<T>[] ?? includes.ToArray();

            if (!includes1.Any()) return value;

            return includes1
                .SelectMany(_ => _.Expressions)
                .Distinct(new ExpressionEqualityComparer())
                .Cast<Expression<Func<T, object>>>()
                .Aggregate(value, (set, expression) => set.Include(expression));
        }
    }
}