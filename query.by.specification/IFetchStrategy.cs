using System.Linq;

namespace query.@by.specification
{
    public interface IFetchStrategy<T>
    {
        IQueryable<T> Include(IQueryable<T> queryable);
    }
}