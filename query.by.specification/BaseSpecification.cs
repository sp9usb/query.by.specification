using System;
using System.Linq.Expressions;

namespace query.@by.specification
{
    public abstract class BaseSpecification<T> : ISpecification<T>
    {
        public abstract Expression<Func<T, bool>> GetPredicate();
    }
}