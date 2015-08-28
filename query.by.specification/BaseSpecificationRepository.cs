using System.Collections.Generic;
using System.Linq;
using query.@by.specification.Extensions;

namespace query.@by.specification
{
    public abstract class BaseSpecificationRepository<T> : ISpecificationRepository<T>
    {
        public abstract IQueryable<T> Expandable { get; }

        public IList<T> FindBy(ISpecification<T> specification, IFetchStrategy<T> fetchStrategy = null)
        {
            return Expandable.Where(specification.GetPredicate()).Include(fetchStrategy).ToList();
        }

        public T First(ISpecification<T> specification, IFetchStrategy<T> fetchStrategy = null)
        {
            return FindBy(specification, fetchStrategy).First();
        }

        public T FirstOrDefault(ISpecification<T> specification, IFetchStrategy<T> fetchStrategy = null)
        {
            return FindBy(specification, fetchStrategy).FirstOrDefault();
        }

        public T Single(ISpecification<T> specification, IFetchStrategy<T> fetchStrategy = null)
        {
            return FindBy(specification, fetchStrategy).Single();
        }

        public T SingleOrDefault(ISpecification<T> specification, IFetchStrategy<T> fetchStrategy = null)
        {
            return FindBy(specification, fetchStrategy).SingleOrDefault();
        }
    }
}