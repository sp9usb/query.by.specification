using System.Linq;

namespace query.@by.specification.Extensions
{
    public static class QueryableExtensions
    {
        public static IQueryable<T> Include<T>(this IQueryable<T> value, IFetchStrategy<T> fetchStrategy)
        {
            return fetchStrategy == null ? value : fetchStrategy.Include(value);
        }
    }
}