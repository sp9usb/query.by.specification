using System;
using System.Linq.Expressions;
using query.@by.specification.Specification.Extensions;

namespace query.@by.specification.Specification
{
    public class AndSpecification<T> : CompositeSpecification<T>
    {
        public AndSpecification(BaseSpecification<T> left, BaseSpecification<T> right)
            : base(left, right)
        {
        }

        public override Expression<Func<T, bool>> GetPredicate()
        {
            return Left.GetPredicate().Compose(Right.GetPredicate(), Expression.AndAlso);
        }
    }
}