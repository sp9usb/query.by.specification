using System;
using System.Linq.Expressions;
using query.@by.specification.Specification;
using query.@by.specification.Tests.Models;

namespace query.@by.specification.Tests.Specifications
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