namespace query.@by.specification
{
    public abstract class CompositeSpecification<T> : BaseSpecification<T>
    {
        protected CompositeSpecification(ISpecification<T> left, ISpecification<T> right)
        {
            Left = left;
            Right = right;
        }

        public ISpecification<T> Left { get; set; }
        public ISpecification<T> Right { get; set; }
    }
}