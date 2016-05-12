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

        public BaseSpecification<T> Left { get; set; }
        public BaseSpecification<T> Right { get; set; }

        internal override IEnumerable<BaseSpecification<T>> GetSpecifications()
        {
            return Left.GetSpecifications().Concat(Right.GetSpecifications());
        }
    }
}