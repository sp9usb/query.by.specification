using System.Collections.Generic;

namespace query.@by.specification
{
    public interface ISpecificationRepository<T>
    {
        IList<T> FindBy(ISpecification<T> specification);

        T First(ISpecification<T> specification);
        T FirstOrDefault(ISpecification<T> specification);
        T Single(ISpecification<T> specification);
        T SingleOrDefault(ISpecification<T> specification);
    }
}