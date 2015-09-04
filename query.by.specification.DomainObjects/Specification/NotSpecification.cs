namespace query.@by.specification.DomainObjects.Specification
{
    public class NotSpecification<T> : BaseSpecification<T>
    {
        public NotSpecification(BaseSpecification<T> inner)
        {
            Inner = inner;
        }

        public BaseSpecification<T> Inner { get; set; }
    }
}