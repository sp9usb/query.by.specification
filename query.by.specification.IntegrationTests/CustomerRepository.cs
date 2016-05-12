using System.Collections.Generic;
using System.Linq;
using query.@by.specification.IntegrationTests.Models;
using query.@by.specification.Repository;

namespace query.@by.specification.IntegrationTests
{
    public class CustomerRepository : BaseSpecificationRepository<Customer>
    {
        private readonly ITestContext _context;

        public CustomerRepository(ITestContext context)
            : base(context)
        {
            _context = context;
        }

        public ICollection<Customer> GetCustomers(string name)
        {
            var customers = _context.Customers.Where(_ => _.FirstName == name).ToList();
            return customers;
        }
    }
}