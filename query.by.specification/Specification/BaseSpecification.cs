using System;
using System.Linq.Expressions;

namespace query.@by.specification.Specification
{
    public abstract class BaseSpecification<T>
    {
        public abstract Expression<Func<T, bool>> GetPredicate();
    }
}