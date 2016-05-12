using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace query.@by.specification.IntegrationTests.Models.Mapping
{
    public class CustomerMap : EntityTypeConfiguration<Customer>
    {
        public CustomerMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.FirstName)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.Surname)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.Email)
                .HasMaxLength(255);

            this.Property(t => t.PhoneNumber)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("Customer");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.FirstName).HasColumnName("FirstName");
            this.Property(t => t.Surname).HasColumnName("Surname");
            this.Property(t => t.Email).HasColumnName("Email");
            this.Property(t => t.PhoneNumber).HasColumnName("PhoneNumber");
        }
    }
}
