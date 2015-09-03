using System.Runtime.Serialization;

namespace query.@by.specification.DataContracts.Specification
{
    [DataContract]
    public class AndSpecification<T> : CompositeSpecification<T>
    {
        public AndSpecification(BaseSpecification<T> left, BaseSpecification<T> right) : base(left, right)
        {
        }
    }
}