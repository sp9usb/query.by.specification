using System;
using System.Linq.Expressions;

namespace query.@by.specification.Specification
{
    public interface ISpecification<T>
    {
        Expression<Func<T, bool>> GetPredicate();
    }
}