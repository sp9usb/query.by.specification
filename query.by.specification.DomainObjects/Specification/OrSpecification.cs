namespace query.@by.specification.DomainObjects.Specification
{
    public class OrSpecification<T> : CompositeSpecification<T>
    {
        public OrSpecification(BaseSpecification<T> left, BaseSpecification<T> right) : base(left, right)
        {
        }
    }
}