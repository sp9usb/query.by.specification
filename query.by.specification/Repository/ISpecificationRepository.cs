using System.Collections.Generic;
using query.@by.specification.Specification;

namespace query.@by.specification.Repository
{
    public interface ISpecificationRepository<T> where T : class
    {
        IList<T> FindBy(ISpecification<T> specification);

        T First(ISpecification<T> specification);
        T FirstOrDefault(ISpecification<T> specification);
        T Single(ISpecification<T> specification);
        T SingleOrDefault(ISpecification<T> specification);
    }
}