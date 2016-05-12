using query.@by.specification.Context;
using query.@by.specification.IntegrationTests.Models;
using query.@by.specification.Repository;

namespace query.@by.specification.IntegrationTests
{
    public class CustomerRepository : BaseSpecificationRepository<Customer>
    {
        public CustomerRepository(IContext context) : base(context)
        {
        }
    }
}