using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace query.@by.specification.Specification
{
    public interface IInclude<T>
    {
        IEnumerable<Expression<Func<T, object>>> Expressions { get; }
    }
}