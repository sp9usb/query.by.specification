using System.Runtime.Serialization;

namespace query.@by.specification.DataContracts.Specification
{
    [DataContract]
    public abstract class CompositeSpecification<T> : BaseSpecification<T>
    {
        protected CompositeSpecification(BaseSpecification<T> left, BaseSpecification<T> right)
        {
            Left = left;
            Right = right;
        }

        [DataMember]
        public BaseSpecification<T> Left { get; set; }

        [DataMember]
        public BaseSpecification<T> Right { get; set; }
    }
}