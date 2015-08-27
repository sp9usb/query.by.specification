using System.Linq;

namespace query.@by.specification
{
    public interface ISpecificationRepository<T>
    {
        IQueryable<T> Where(ISpecification<T> specification);
    }
}