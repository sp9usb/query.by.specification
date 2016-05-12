using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace query.@by.specification.IntegrationTests.Models.Mapping
{
    public class LineItemMap : EntityTypeConfiguration<LineItem>
    {
        public LineItemMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            // Table & Column Mappings
            this.ToTable("LineItem");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.OrderId).HasColumnName("OrderId");
            this.Property(t => t.ProductId).HasColumnName("ProductId");
            this.Property(t => t.Quatity).HasColumnName("Quatity");

            // Relationships
            this.HasRequired(t => t.Order)
                .WithMany(t => t.LineItems)
                .HasForeignKey(d => d.OrderId);
            this.HasRequired(t => t.Product)
                .WithMany(t => t.LineItems)
                .HasForeignKey(d => d.ProductId);

        }
    }
}
