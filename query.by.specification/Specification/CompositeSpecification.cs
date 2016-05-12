using System.Collections.Generic;
using System.Linq;

namespace query.@by.specification.Specification
{
    public abstract class CompositeSpecification<T> : BaseSpecification<T>
    {
        protected CompositeSpecification(BaseSpecification<T> left, BaseSpecification<T> right)
        {
            Left = left;
            Right = right;
        }

        protected BaseSpecification<T> Left { get; private set; }
        protected BaseSpecification<T> Right { get; private set; }

        internal override IEnumerable<BaseSpecification<T>> GetSpecifications()
        {
            return Left.GetSpecifications().Concat(Right.GetSpecifications());
        }
    }
}