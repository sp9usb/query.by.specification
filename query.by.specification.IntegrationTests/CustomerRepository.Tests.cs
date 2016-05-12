using query.@by.specification.IntegrationTests.Models;
using query.@by.specification.IntegrationTests.Specifications;
using query.@by.specification.Specification;
using query.@by.specification.Specification.Extensions;
using Shouldly;
using Xunit;

namespace query.@by.specification.IntegrationTests
{
    public class CustomerRepositoryTests
    {
        private readonly CustomerRepository _sut;

        public CustomerRepositoryTests()
        {
            _sut = new CustomerRepository(new TestContext());
        }

        [Fact]
        public void List_SpecificationWithMatch_ReturnsCorrectNumberOfRecords()
        {
            var customers = _sut.List(new CustomerFirstNameSpecification("Andie"));
            customers.Count.ShouldBe(1);
        }

        [Fact]
        public void List_AndSpecificationWithMatch_ReturnsCorrectNumberOfRecords()
        {
            var customers =
                _sut.List(new CustomerFirstNameSpecification("Ryan").And(new CustomerSurnameSpecification("Bartsch")));
            customers.Count.ShouldBe(1);
        }

        [Fact]
        public void List_JoinSpecificationWithMatch_ReturnsCorrectNumberOfRecords()
        {
            var customers = _sut.List(new AddressSuburbSpecification("Prospect"));
            customers.Count.ShouldBe(1);
        }

        [Fact]
        public void List_SpecificationWithNoMatch_ReturnsCorrectNumberOfRecords()
        {
            var customers = _sut.List(new CustomerFirstNameSpecification("Brad"));
            customers.Count.ShouldBe(0);
        }

        [Fact]
        public void List_AndSpecificationWithNoMatch_ReturnsCorrectNumberOfRecords()
        {
            var customers =
                _sut.List(new CustomerFirstNameSpecification("Ryan").And(new CustomerSurnameSpecification("Smith")));
            customers.Count.ShouldBe(0);
        }

        [Fact]
        public void List_JoinSpecificationWithNoMatch_ReturnsCorrectNumberOfRecords()
        {
            var customers = _sut.List(new AddressSuburbSpecification("Tanunda"));
            customers.Count.ShouldBe(0);
        }

        [Fact]
        public void List_OrSpecificationWithMatch_ReturnsCorrectNumberOfRecords()
        {
            var customers =
                _sut.List(new CustomerFirstNameSpecification("Peter").Or(new CustomerFirstNameSpecification("Ryan")));
            customers.Count.ShouldBe(1);
        }

        [Fact]
        public void List_OrSpecificationWithNoMatch_ReturnsCorrectNumberOfRecords()
        {
            var customers =
                _sut.List(new CustomerFirstNameSpecification("Peter").Or(new CustomerFirstNameSpecification("Jane")));
            customers.Count.ShouldBe(0);
        }

        [Fact]
        public void List_NotSpecificationWithMatch_ReturnsCorrectNumberOfRecords()
        {
            var customers = _sut.List(new NotSpecification<Customer>(new CustomerFirstNameSpecification("Ryan")));
            customers.Count.ShouldBe(1);
        }

        [Fact]
        public void List_NotOrSpecificationWithMatch_ReturnsCorrectNumberOfRecords()
        {
            var customers = _sut.List(new NotSpecification<Customer>(new CustomerFirstNameSpecification("Peter")));
            customers.Count.ShouldBe(2);
        }

        [Fact]
        public void List_NotSpecificationWithNoMatch_ReturnsCorrectNumberOfRecords()
        {
            var customers =
                _sut.List(
                    new NotSpecification<Customer>(
                        new CustomerFirstNameSpecification("Ryan").Or(new CustomerFirstNameSpecification("Andie"))));
            customers.Count.ShouldBe(0);
        }
    }
}