using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace query.@by.specification.IntegrationTests.Models.Mapping
{
    public class AddressMap : EntityTypeConfiguration<Address>
    {
        public AddressMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.Line1)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.Line2)
                .HasMaxLength(50);

            this.Property(t => t.State)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.Suburb)
                .IsRequired()
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("Address");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.CustomerId).HasColumnName("CustomerId");
            this.Property(t => t.Line1).HasColumnName("Line1");
            this.Property(t => t.Line2).HasColumnName("Line2");
            this.Property(t => t.State).HasColumnName("State");
            this.Property(t => t.Suburb).HasColumnName("Suburb");
            this.Property(t => t.Postcode).HasColumnName("Postcode");

            // Relationships
            this.HasRequired(t => t.Customer)
                .WithMany(t => t.Addresses)
                .HasForeignKey(d => d.CustomerId);

        }
    }
}
