using System;
using System.Linq.Expressions;
using query.@by.specification.Specification.Extensions;

namespace query.@by.specification.Specification
{
    public class OrSpecification<T> : CompositeSpecification<T>
    {
        public OrSpecification(BaseSpecification<T> left, BaseSpecification<T> right)
            : base(left, right)
        {
        }

        public override Expression<Func<T, bool>> GetPredicate()
        {
            return Left.GetPredicate().Compose(Right.GetPredicate(), Expression.OrElse);
        }
    }
}