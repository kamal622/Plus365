using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace _365Plus.Data.Models.Mapping
{
    public class CodeMap : EntityTypeConfiguration<Code>
    {
        public CodeMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.CodeValue)
                .IsRequired()
                .HasMaxLength(500);

            this.Property(t => t.Type)
                .IsRequired()
                .HasMaxLength(500);

            // Table & Column Mappings
            this.ToTable("Codes");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.CodeValue).HasColumnName("CodeValue");
            this.Property(t => t.Type).HasColumnName("Type");
            this.Property(t => t.Points).HasColumnName("Points");
            this.Property(t => t.IsActive).HasColumnName("IsActive");
            this.Property(t => t.CreatedDate).HasColumnName("CreatedDate");
            this.Property(t => t.ModifiedDate).HasColumnName("ModifiedDate");
            this.Property(t => t.CreatedBy).HasColumnName("CreatedBy");
            this.Property(t => t.ModifiedBy).HasColumnName("ModifiedBy");
        }
    }
}
