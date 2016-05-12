using System;
using System.Linq.Expressions;
using query.@by.specification.IntegrationTests.Models;
using query.@by.specification.Specification;

namespace query.@by.specification.IntegrationTests.Specifications
{
    public class CustomerFirstNameSpecification : BaseSpecification<Customer>
    {
        private readonly string _firstName;

        public CustomerFirstNameSpecification(string firstName)
        {
            _firstName = firstName;
        }


        public override Expression<Func<Customer, bool>> Predicate
        {
            get
            {
                return customer => customer.FirstName == _firstName;
            }
        }
    }
}