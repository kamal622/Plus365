using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace _365Plus.Data.Models.Mapping
{
    public class EmailTemplateMap : EntityTypeConfiguration<EmailTemplate>
    {
        public EmailTemplateMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(250);

            this.Property(t => t.Subject)
                .IsRequired()
                .HasMaxLength(250);

            this.Property(t => t.Body)
                .IsRequired();

            // Table & Column Mappings
            this.ToTable("EmailTemplate");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.Subject).HasColumnName("Subject");
            this.Property(t => t.Body).HasColumnName("Body");
            this.Property(t => t.TemplateTypeId).HasColumnName("TemplateTypeId");
            this.Property(t => t.LanguageId).HasColumnName("LanguageId");
            this.Property(t => t.IsActive).HasColumnName("IsActive");
            this.Property(t => t.CreatedDate).HasColumnName("CreatedDate");
            this.Property(t => t.ModifiedDate).HasColumnName("ModifiedDate");
            this.Property(t => t.CreatedBy).HasColumnName("CreatedBy");
            this.Property(t => t.ModifiedBy).HasColumnName("ModifiedBy");

            // Relationships
            this.HasRequired(t => t.EmailTemplateType)
                .WithMany(t => t.EmailTemplates)
                .HasForeignKey(d => d.TemplateTypeId);
            this.HasRequired(t => t.Language)
                .WithMany(t => t.EmailTemplates)
                .HasForeignKey(d => d.LanguageId);

        }
    }
}
