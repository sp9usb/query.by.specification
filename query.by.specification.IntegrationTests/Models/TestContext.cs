using System.Data.Common;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using query.@by.specification.IntegrationTests.Models.Mapping;

namespace query.@by.specification.IntegrationTests.Models
{
    public class TestContext : DbContext, ITestContext
    {
        public TestContext()
        {
        }

        public TestContext(string nameOrConnectionString)
            : base(nameOrConnectionString)
	    {
        }

        public TestContext(DbConnection existingConnection)
            : base(existingConnection, false)
        {
        }

        public DbSet<Address> Addresses { get; set; }
        public DbSet<Customer> Customers { get; set; }
        //public IDbSet<LineItem> LineItems { get; set; }
        //public IDbSet<Order> Orders { get; set; }
        //public IDbSet<Product> Products { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new AddressMap());
            modelBuilder.Configurations.Add(new CustomerMap());
            //modelBuilder.Configurations.Add(new LineItemMap());
            //modelBuilder.Configurations.Add(new OrderMap());
            //modelBuilder.Configurations.Add(new ProductMap());

            base.OnModelCreating(modelBuilder);
        }

        public IQueryable<T> Table<T>() where T : class
        {
            return Set<T>();
        }
    }
}
