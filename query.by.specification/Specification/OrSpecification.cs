using System;
using System.Linq.Expressions;
using LinqKit;

namespace query.@by.specification.Specification
{
    public sealed class OrSpecification<T> : CompositeSpecification<T>
    {
        public OrSpecification(BaseSpecification<T> left, BaseSpecification<T> right)
            : base(left, right)
        {
        }
        public override Expression<Func<T, bool>> Predicate => Left.Predicate.Or(Right.Predicate);
    }
}