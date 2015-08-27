using System;
using System.Linq.Expressions;

namespace query.@by.specification
{
    public interface ISpecification<T>
    {
        Expression<Func<T, bool>> GetPredicate();
    }
}