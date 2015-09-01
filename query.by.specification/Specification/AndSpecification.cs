using System;
using System.Linq.Expressions;
using query.@by.specification.Specification.Extensions;

namespace query.@by.specification.Specification
{
    public class AndSpecification<T> : CompositeSpecification<T>
    {
        public AndSpecification(ISpecification<T> left, ISpecification<T> right) : base(left, right)
        {
        }

        public override Expression<Func<T, bool>> GetPredicate()
        {
            return Left.GetPredicate().Compose(Right.GetPredicate(), Expression.AndAlso);
        }
    }
}