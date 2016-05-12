using System.Collections.Generic;
using query.@by.specification.Specification;

namespace query.@by.specification.Repository
{
    public interface ISpecificationRepository<T> where T : class
    {
        T First(BaseSpecification<T> specification);
        T FirstOrDefault(BaseSpecification<T> specification);
        IList<T> List(BaseSpecification<T> specification);
        T Single(BaseSpecification<T> specification);
        T SingleOrDefault(BaseSpecification<T> specification);
    }
}