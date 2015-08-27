using System;
using System.Linq.Expressions;
using System.Runtime.Serialization;

namespace query.@by.specification
{
    [DataContract]
    public class AndSpecification<T> : CompositeSpecification<T>
    {
        public AndSpecification(ISpecification<T> left, ISpecification<T> right) : base(left, right)
        {
        }

        public override Expression<Func<T, bool>> GetPredicate()
        {
            var parameter = Expression.Parameter(typeof (T), typeof (T).ToString());

            var conjunction =
                Expression.Lambda<Func<T, bool>>(
                    Expression.AndAlso(Expression.Invoke(Left.GetPredicate(), parameter),
                        Expression.Invoke(Right.GetPredicate(), parameter)), parameter);

            return conjunction;
        }
    }
}