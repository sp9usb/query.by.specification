using System.Collections.Generic;
using System.Linq;

namespace query.@by.specification
{
    public interface ISpecificationRepository<T>
    {
        IList<T> FindBy(ISpecification<T> specification);
    }

    public abstract class BaseSpecificationRepository<T> : ISpecificationRepository<T>
    {
        public abstract IQueryable<T> Expandable { get; }

        public IList<T> FindBy(ISpecification<T> specification)
        {
            return Expandable.Where(specification.GetPredicate()).ToList();
        }
    }
}