using System.Data.Entity;
using query.@by.specification.Context;

namespace query.@by.specification.IntegrationTests.Models
{
    public interface ITestContext : IContext
    {
        DbSet<Address> Addresses { get; set; }
        DbSet<Customer> Customers { get; set; }
        //IDbSet<LineItem> LineItems { get; set; }
        //IDbSet<Order> Orders { get; set; }
        //IDbSet<Product> Products { get; set; }
    }
}