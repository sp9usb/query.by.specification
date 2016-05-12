using System;
using System.Linq.Expressions;
using query.@by.specification.IntegrationTests.Models;
using query.@by.specification.Specification;

namespace query.@by.specification.IntegrationTests.Specifications
{
    public class CustomerSurnameSpecification : BaseSpecification<Customer>
    {
        private readonly string _surname;

        public CustomerSurnameSpecification(string surname)
        {
            _surname = surname;
        }


        public override Expression<Func<Customer, bool>> Predicate
        {
            get
            {
                return customer => customer.Surname == _surname;
            }
        }
    }
}