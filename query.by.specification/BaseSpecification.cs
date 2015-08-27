using System;
using System.Linq.Expressions;
using System.Runtime.Serialization;

namespace query.@by.specification
{
    [DataContract]
    public abstract class BaseSpecification<T> : ISpecification<T>
    {
        public abstract Expression<Func<T, bool>> GetPredicate();
    }
}