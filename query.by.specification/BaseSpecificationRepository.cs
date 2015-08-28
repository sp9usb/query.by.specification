using System.Collections.Generic;
using System.Linq;
using query.@by.specification.Extensions;

namespace query.@by.specification
{
    public abstract class BaseSpecificationRepository<T> : ISpecificationRepository<T>
    {
        public abstract IQueryable<T> GetQuery();
        public abstract IQueryable<T> AsExpandable(IQueryable<T> query);

        public IList<T> FindBy(ISpecification<T> specification, IFetchStrategy<T> fetchStrategy = null)
        {
            return AsExpandable(GetQuery(fetchStrategy)).Where(specification.GetPredicate()).Include(fetchStrategy).ToList();
        }

        private IQueryable<T> GetQuery(IFetchStrategy<T> fetchStrategy)
        {
            return fetchStrategy != null ? fetchStrategy.Include(GetQuery()) : GetQuery();
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