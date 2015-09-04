namespace query.@by.specification.DomainObjects.Specification
{
    public class AndSpecification<T> : CompositeSpecification<T>
    {
        public AndSpecification(BaseSpecification<T> left, BaseSpecification<T> right) : base(left, right)
        {
        }
    }
}