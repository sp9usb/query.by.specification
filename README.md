# query.by.specification

A simple query-by-specification framework for Entity Framework that uses LINQ expressions

### Overview

The repository pattern is quite often the default option when building a data access layer:

    _repository.GetCustomers(firstName: "Ryan", surname: "Bartsch");

In some situations this approach can cause a few issues, whereby more and more repository methods are added for every concievable combination of queryable parameters:

    public interface ICustomerRepository
    {
        ICollection<Customer> GetCustomersByFirstName(string fistName);
        ICollection<Customer> GetCustomersBySurname(string surname);
        ICollection<Customer> GetCustomersByFirstNameAndSurname(string fistName, string surname);
        ICollection<Customer> GetCustomersWithAge(string operation, int age);
        ICollection<Customer> GetCustomersByFirstNameSurnameAndAge(string fistName, string surname, string operation, int age);
        // ...
    }

This can lead to violations of OO design priciples such as OCP, ISP, SRP, & DRY, which ultimately has a negative impact on the quality of a solution.

To solve this problem, the specification pattern can become a viable approach.

Instead of defining more and more methods on a repository, we create reusable specifications. The following is an example specification:

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

These specifications can be chained together using a fluent interface and queried as follows:

    _repository.List(new CustomerSurnameSpecification("Ryan").And(new NotSpecification<Customer>(new CustomerFirstNameSpecification("Smith").Or(new CustomerFirstNameSpecification("Jones")))));

Pretty nice, huh? Ok the fluent interface is pretty crude, but you could easily write your own internal DSL to make things really user friendly.

It's also possible to customise your fetch strategy (to aviod n+1 issues), by making your specifications implement IInclude`<T`>:

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

### Nuget

This repository has been published to the public nuget.org feed:
[https://www.nuget.org/packages/query.by.specification/](https://www.nuget.org/packages/query.by.specification/)

### Blogs

* [Query-by-specification part 1 - the problem with repositories](http://www.blog.ryanbartsch.com/2016/04/query-by-specification-part-1/)
* [Query-by-specification part 2 - specifications to the rescue](http://www.blog.ryanbartsch.com/2016/05/query-by-specification-part-2/)