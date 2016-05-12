using System.Linq;

namespace query.@by.specification.Context
{
    public interface IContext
    {
        IQueryable<T> Table<T>() where T : class;
    }
}
