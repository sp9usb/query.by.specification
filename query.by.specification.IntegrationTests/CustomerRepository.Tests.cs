using query.@by.specification.Specification;
using query.@by.specification.Specification.Extensions;
using query.@by.specification.Tests.Models;
using query.@by.specification.Tests.Specifications;
using Shouldly;
using Xunit;

namespace query.by.specification.Tests
{
    public class CustomerRepositoryTests
    {
        private readonly CustomerRepository _sut;

        public CustomerRepositoryTests()
        {
            _sut = new CustomerRepository(new TestContext());
        }

        [Fact]
        public void Test1()
        {
            var customers = _sut.List(new CustomerFirstNameSpecification("Andie"));
            customers.Count.ShouldBe(1);
        }

        [Fact]
        public void Test2()
        {
            var customers = _sut.List(new CustomerFirstNameSpecification("Ryan").And(new CustomerSurnameSpecification("Bartsch")));
            customers.Count.ShouldBe(1);
        }

        [Fact]
        public void Test3()
        {
            var customers = _sut.List(new AddressSuburbSpecification("Prospect"));
            customers.Count.ShouldBe(1);
        }

        [Fact]
        public void Test4()
        {
            var customers = _sut.List(new CustomerFirstNameSpecification("Brad"));
            customers.Count.ShouldBe(0);
        }

        [Fact]
        public void Test5()
        {
            var customers = _sut.List(new CustomerFirstNameSpecification("Ryan").And(new CustomerSurnameSpecification("Smith")));
            customers.Count.ShouldBe(0);
        }

        [Fact]
        public void Test6()
        {
            var customers = _sut.List(new AddressSuburbSpecification("Tanunda"));
            customers.Count.ShouldBe(0);
        }

        [Fact]
        public void Test7()
        {
            var customers = _sut.List(new CustomerFirstNameSpecification("Ryan").Or(new CustomerSurnameSpecification("Reid")));
            customers.Count.ShouldBe(2);
        }

        [Fact]
        public void Test8()
        {
            var customers = _sut.List(new CustomerFirstNameSpecification("Peter").Or(new CustomerFirstNameSpecification("Ryan")));
            customers.Count.ShouldBe(1);
        }

        [Fact]
        public void Test9()
        {
            var customers = _sut.List(new CustomerFirstNameSpecification("Peter").Or(new CustomerFirstNameSpecification("Jane")));
            customers.Count.ShouldBe(0);
        }

        [Fact]
        public void Test10()
        {
            var customers = _sut.List(new NotSpecification<Customer>(new CustomerFirstNameSpecification("Ryan")));
            customers.Count.ShouldBe(1);
        }

        [Fact]
        public void Test11()
        {
            var customers = _sut.List(new NotSpecification<Customer>(new CustomerFirstNameSpecification("Peter")));
            customers.Count.ShouldBe(2);
        }

        [Fact]
        public void Test12()
        {
            var customers = _sut.List(new NotSpecification<Customer>(new CustomerFirstNameSpecification("Ryan").Or(new CustomerFirstNameSpecification("Andie"))));
            customers.Count.ShouldBe(0);
        }
    }
}
