using System;
using System.Collections.Generic;
using System.Linq;

namespace query.@by.specification
{
    public interface ISpecificationRepository<T>
    {
        IList<T> FindBy(ISpecification<T> specification, IFetchStrategy<T> fetchStrategy = null);
        T First(ISpecification<T> specification, IFetchStrategy<T> fetchStrategy = null);
        T FirstOrDefault(ISpecification<T> specification, IFetchStrategy<T> fetchStrategy = null);
        T Single(ISpecification<T> specification, IFetchStrategy<T> fetchStrategy = null);
        T SingleOrDefault(ISpecification<T> specification, IFetchStrategy<T> fetchStrategy = null);
    }
}