using System.Runtime.Serialization;

namespace query.@by.specification
{
    [DataContract]
    public abstract class CompositeSpecification<T> : BaseSpecification<T>
    {
        protected CompositeSpecification(ISpecification<T> left, ISpecification<T> right)
        {
            Left = left;
            Right = right;
        }

        [DataMember]
        public ISpecification<T> Left { get; set; }

        [DataMember]
        public ISpecification<T> Right { get; set; }
    }
}