using query.@by.specification.FetchStrategy;

namespace query.@by.specification.Repository
{
    public interface IFetchStrategyRepository<T> : ISpecificationRepository<T> where T : class
    {
        ISpecificationRepository<T> WithFetchStrategy(IFetchStrategy<T> fetchStrategy);
    }
}