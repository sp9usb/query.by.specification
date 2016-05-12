using System;
using System.Linq.Expressions;
using query.@by.specification.Specification;
using query.@by.specification.Tests.Models;

namespace query.@by.specification.Tests.Specifications
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