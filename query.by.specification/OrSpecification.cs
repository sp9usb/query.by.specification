using System;
using System.Linq.Expressions;

namespace query.@by.specification
{
    public class OrSpecification<T> : CompositeSpecification<T>
    {
        public OrSpecification(ISpecification<T> left, ISpecification<T> right) : base(left, right)
        {
        }

        public override Expression<Func<T, bool>> GetPredicate()
        {
            var parameter = Expression.Parameter(typeof (T), typeof (T).ToString());

            var disjunction =
                Expression.Lambda<Func<T, bool>>(
                    Expression.OrElse(Expression.Invoke(Left.GetPredicate(), parameter),
                        Expression.Invoke(Right.GetPredicate(), parameter)), parameter);

            return disjunction;
        }
    }
}