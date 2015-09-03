using System.Runtime.Serialization;

namespace query.@by.specification.DataContracts.Specification
{
    [DataContract]
    public class OrSpecification<T> : CompositeSpecification<T>
    {
        public OrSpecification(BaseSpecification<T> left, BaseSpecification<T> right) : base(left, right)
        {
        }
    }
}