namespace query.@by.specification.Specification.Extensions
{
    public static class SpecificationExtensions
    {
        public static BaseSpecification<T> And<T>(this BaseSpecification<T> left, BaseSpecification<T> right)
        {
            return new AndSpecification<T>(left, right);
        }

        public static BaseSpecification<T> Or<T>(this BaseSpecification<T> left, BaseSpecification<T> right)
        {
            return new OrSpecification<T>(left, right);
        }

        public static BaseSpecification<T> Not<T>(this BaseSpecification<T> inner)
        {
            return new NotSpecification<T>(inner);
        }
    }
}