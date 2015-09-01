using System.Collections.Generic;

namespace query.@by.specification.FetchStrategy
{
    public interface IFetchStrategy<T>
    {
        IList<Include<T>> Includes();
    }
}