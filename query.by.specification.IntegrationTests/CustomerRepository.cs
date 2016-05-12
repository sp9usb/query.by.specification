using System.Linq;
using query.@by.specification.Context;
using query.@by.specification.Repository;
using query.@by.specification.Tests.Models;

namespace query.by.specification.Tests
{
    public class CustomerRepository : BaseSpecificationRepository<Customer>
    {
        public CustomerRepository(IContext context) : base(context)
        {
        }
    }
}