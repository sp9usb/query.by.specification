using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using query.@by.specification.Specification.Extensions;

namespace query.@by.specification.Specification
{
    public sealed class NotSpecification<T> : BaseSpecification<T>
    {
        public NotSpecification(BaseSpecification<T> inner)
        {
            Inner = inner;
        }

        public BaseSpecification<T> Inner { get; set; }

        public override Expression<Func<T, bool>> Predicate => Inner.Predicate.Invert();

        internal override IEnumerable<BaseSpecification<T>> GetSpecifications()
        {
            return Inner.GetSpecifications();
        }
    }
}