using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using query.@by.specification.Specification;
using query.@by.specification.Tests.Models;

namespace query.by.specification.Tests.Specifications
{
    public class AddressSuburbSpecification : BaseSpecification<Customer>, IInclude<Customer>
    {
        private readonly string _addressSuburb;

        public AddressSuburbSpecification(string addressSuburb)
        {
            _addressSuburb = addressSuburb;
        }

        public override Expression<Func<Customer, bool>> Predicate
        {
            get
            {
                return customer => customer.Addresses.Any(address => address.Suburb == _addressSuburb);
            }
        }

        public IEnumerable<Expression<Func<Customer, object>>> Expressions
        {
            get
            {
                Expression<Func<Customer, object>> addresses = customer => customer.Addresses;
                return new[] { addresses };
            }
        }
    }
}
