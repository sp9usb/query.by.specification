using System.Runtime.Serialization;

namespace query.@by.specification.DataContracts.Specification
{
    [DataContract]
    public class NotSpecification<T> : BaseSpecification<T>
    {
        public NotSpecification(BaseSpecification<T> inner)
        {
            Inner = inner;
        }

        [DataMember]
        public BaseSpecification<T> Inner { get; set; }
    }
}