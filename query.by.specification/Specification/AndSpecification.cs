using LinqKit;
using System;
using System.Linq.Expressions;

namespace query.@by.specification.Specification
{
    public sealed class AndSpecification<T> : CompositeSpecification<T>
    {
        public AndSpecification(BaseSpecification<T> left, BaseSpecification<T> right)
            : base(left, right)
        {
        }

        public override Expression<Func<T, bool>> Predicate => Left.Predicate.And(Right.Predicate);
    }
}