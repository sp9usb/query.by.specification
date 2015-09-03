using System.Collections.Generic;

namespace query.@by.specification.DataContracts.FetchStrategy
{
    public interface IFetchStrategy<T>
    {
        IList<Include<T>> Includes();
    }
}