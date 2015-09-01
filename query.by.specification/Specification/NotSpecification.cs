using System;
using System.Linq.Expressions;

namespace query.@by.specification.Specification
{
    public class NotSpecification<T> : BaseSpecification<T>
    {
        public NotSpecification(ISpecification<T> inner)
        {
            Inner = inner;
        }

        public ISpecification<T> Inner { get; set; }

        public override Expression<Func<T, bool>> GetPredicate()
        {
            var parameter = Expression.Parameter(typeof (T), typeof (T).ToString());

            var negation =
                Expression.Lambda<Func<T, bool>>(Expression.Not(Expression.Invoke(Inner.GetPredicate(), parameter)),
                    parameter);

            return negation;
        }
    }
}