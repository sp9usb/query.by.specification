using System;
using System.Collections.Generic;
using System.Linq;
using query.@by.specification.FetchStrategy;
using query.@by.specification.Specification;

namespace query.@by.specification.Repository
{
    public abstract class BaseSpecificationRepository<T> : IFetchStrategyRepository<T> where T : class
    {
        protected internal IFetchStrategy<T> FetchStrategy;
        public abstract IQueryable<T> Table { get; }

        public ISpecificationRepository<T> WithFetchStrategy(IFetchStrategy<T> fetchStrategy)
        {
            var clone = MemberwiseClone() as BaseSpecificationRepository<T>;
            if (clone == null)
            {
                throw new Exception("Unable to create shallow clone of repository");
            }

            clone.FetchStrategy = fetchStrategy;

            return clone;
        }

        public IList<T> FindBy(ISpecification<T> specification)
        {
            return GetQuery(Table, FetchStrategy).Where(specification.GetPredicate()).ToList();
        }

        public T First(ISpecification<T> specification)
        {
            return FindBy(specification).First();
        }

        public T FirstOrDefault(ISpecification<T> specification)
        {
            return FindBy(specification).FirstOrDefault();
        }

        public T Single(ISpecification<T> specification)
        {
            return FindBy(specification).Single();
        }

        public T SingleOrDefault(ISpecification<T> specification)
        {
            return FindBy(specification).SingleOrDefault();
        }

        protected abstract IQueryable<T> GetQuery(IQueryable<T> query, IFetchStrategy<T> fetchStrategy);
    }
}