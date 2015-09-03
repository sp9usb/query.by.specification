using System;
using System.Linq.Expressions;
using System.Runtime.Serialization;

namespace query.@by.specification.DataContracts.FetchStrategy
{
    [DataContract]
    public class Include<T>
    {
        public Include(Expression<Func<T, object>> expression)
        {
            Expression = expression;
        }

        [DataMember]
        public Expression<Func<T, object>> Expression { get; set; }
    }
}