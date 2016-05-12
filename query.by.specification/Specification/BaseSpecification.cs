using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace query.@by.specification.Specification
{
    public abstract class BaseSpecification<T>
    {
        public abstract Expression<Func<T, bool>> Predicate { get; }

        internal virtual IEnumerable<BaseSpecification<T>> GetSpecifications()
        {
            return new[] {this};
        }
    }
}