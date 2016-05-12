using System;
using System.IO;
using NUnit.Framework;
using query.@by.specification.IntegrationTests.Models;
using query.@by.specification.IntegrationTests.Specifications;
using query.@by.specification.Specification;
using query.@by.specification.Specification.Extensions;
using Shouldly;
using TestContext = query.@by.specification.IntegrationTests.Models.TestContext;

namespace query.@by.specification.IntegrationTests
{
    [TestFixture]
    public class CustomerRepositoryTests
    {
        private readonly CustomerRepository _sut;

        public CustomerRepositoryTests()
        {
            AppDomain.CurrentDomain.SetData("DataDirectory", Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data"));
            var context = new TestContext("qbs1");
            _sut = new CustomerRepository(context);
        }

        [Test]
        public void List_SpecificationWithMatch_ReturnsCorrectNumberOfRecords()
        {
            var customers = _sut.List(new CustomerFirstNameSpecification("Andie"));
            customers.Count.ShouldBe(1);
        }

        [Test]
        public void List_AndSpecificationWithMatch_ReturnsCorrectNumberOfRecords()
        {
            var customers =
                _sut.List(new CustomerFirstNameSpecification("Ryan").And(new CustomerSurnameSpecification("Bartsch")));
            customers.Count.ShouldBe(1);
        }

        [Test]
        public void List_JoinSpecificationWithMatch_ReturnsCorrectNumberOfRecords()
        {
            var customers = _sut.List(new AddressSuburbSpecification("Prospect"));
            customers.Count.ShouldBe(1);
        }

        [Test]
        public void List_SpecificationWithNoMatch_ReturnsCorrectNumberOfRecords()
        {
            var customers = _sut.List(new CustomerFirstNameSpecification("Brad"));
            customers.Count.ShouldBe(0);
        }

        [Test]
        public void List_AndSpecificationWithNoMatch_ReturnsCorrectNumberOfRecords()
        {
            var customers =
                _sut.List(new CustomerFirstNameSpecification("Ryan").And(new CustomerSurnameSpecification("Smith")));
            customers.Count.ShouldBe(0);
        }

        [Test]
        public void List_JoinSpecificationWithNoMatch_ReturnsCorrectNumberOfRecords()
        {
            var customers = _sut.List(new AddressSuburbSpecification("Tanunda"));
            customers.Count.ShouldBe(0);
        }

        [Test]
        public void List_OrSpecificationWithMatch_ReturnsCorrectNumberOfRecords()
        {
            var customers =
                _sut.List(new CustomerFirstNameSpecification("Peter").Or(new CustomerFirstNameSpecification("Ryan")));
            customers.Count.ShouldBe(1);
        }

        [Test]
        public void List_OrSpecificationWithNoMatch_ReturnsCorrectNumberOfRecords()
        {
            var customers =
                _sut.List(new CustomerFirstNameSpecification("Peter").Or(new CustomerFirstNameSpecification("Jane")));
            customers.Count.ShouldBe(0);
        }

        [Test]
        public void List_NotSpecificationWithMatch_ReturnsCorrectNumberOfRecords()
        {
            var customers = _sut.List(new NotSpecification<Customer>(new CustomerFirstNameSpecification("Ryan")));
            customers.Count.ShouldBe(1);
        }

        [Test]
        public void List_NotOrSpecificationWithMatch_ReturnsCorrectNumberOfRecords()
        {
            var customers = _sut.List(new NotSpecification<Customer>(new CustomerFirstNameSpecification("Peter")));
            customers.Count.ShouldBe(2);
        }

        [Test]
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