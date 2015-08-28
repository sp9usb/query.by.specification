using System.Collections.Generic;
using System.Linq;

namespace query.@by.specification
{
    public abstract class BaseSpecificationRepository<T> : ISpecificationRepository<T>
    {
        public abstract IQueryable<T> Expandable { get; }

        public IList<T> FindBy(ISpecification<T> specification)
        {
            return Expandable.Where(specification.GetPredicate()).ToList();
        }

        public T First(ISpecification<T> specification)
        {
            return Expandable.First(specification.GetPredicate());
        }

        public T FirstOrDefault(ISpecification<T> specification)
        {
            return Expandable.FirstOrDefault(specification.GetPredicate());
        }

        public T Single(ISpecification<T> specification)
        {
            return Expandable.Single(specification.GetPredicate());
        }

        public T SingleOrDefault(ISpecification<T> specification)
        {
            return Expandable.SingleOrDefault(specification.GetPredicate());
        }
    }
}