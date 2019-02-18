using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace _365Plus.Data.Models.Mapping
{
    public class EmailTemplateTypeMap : EntityTypeConfiguration<EmailTemplateType>
    {
        public EmailTemplateTypeMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Type)
                .HasMaxLength(250);

            // Table & Column Mappings
            this.ToTable("EmailTemplateType");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.Type).HasColumnName("Type");
            this.Property(t => t.IsActive).HasColumnName("IsActive");
        }
    }
}
