using System;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Reflection;

namespace query.by.specification.Tests.Models
{
    public class TestContext : DbContext, ITestContext
    {
        public TestContext() : base("Test")
	    {
        }

        public IDbSet<Address> Addresses { get; set; }
        public IDbSet<Customer> Customers { get; set; }
        public IDbSet<LineItem> LineItems { get; set; }
        public IDbSet<Order> Orders { get; set; }
        public IDbSet<Product> Products { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            var typesToRegister =
                Assembly.GetExecutingAssembly()
                    .GetTypes()
                    .Where(
                        type =>
                            !string.IsNullOrEmpty(type.Namespace) &&
                            type.Namespace.ToLower().EndsWith("mapping") &&
                            type.BaseType != null &&
                            type.BaseType.IsGenericType &&
                            type.BaseType.GetGenericTypeDefinition() == typeof(EntityTypeConfiguration<>));

            foreach (var configurationInstance in typesToRegister.Select(Activator.CreateInstance))
            {
                modelBuilder.Configurations.Add((dynamic)configurationInstance);
            }

            base.OnModelCreating(modelBuilder);
        }

        public IQueryable<T> Table<T>() where T : class
        {
            return Set<T>();
        }
    }
}
