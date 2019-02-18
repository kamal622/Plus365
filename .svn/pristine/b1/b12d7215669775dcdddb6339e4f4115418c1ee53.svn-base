using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace _365Plus.Data.Models.Mapping
{
    public class DomainDetailMap : EntityTypeConfiguration<DomainDetail>
    {
        public DomainDetailMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Name)
                .HasMaxLength(500);

            this.Property(t => t.Domain)
                .HasMaxLength(500);

            // Table & Column Mappings
            this.ToTable("DomainDetails");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.Domain).HasColumnName("Domain");
        }
    }
}
