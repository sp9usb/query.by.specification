using System.Data.Entity;
using query.@by.specification.Context;

namespace query.@by.specification.Tests.Models
{
    public interface ITestContext : IContext
    {
        IDbSet<Address> Addresses { get; set; }
        IDbSet<Customer> Customers { get; set; }
        IDbSet<LineItem> LineItems { get; set; }
        IDbSet<Order> Orders { get; set; }
        IDbSet<Product> Products { get; set; }
    }
}