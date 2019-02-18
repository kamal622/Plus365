using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace _365Plus.Data.Models.Mapping
{
    public class HTMLPageContentMap : EntityTypeConfiguration<HTMLPageContent>
    {
        public HTMLPageContentMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            // Table & Column Mappings
            this.ToTable("HTMLPageContent");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.HTMLPageId).HasColumnName("HTMLPageId");
            this.Property(t => t.HTMLContent).HasColumnName("HTMLContent");
            this.Property(t => t.LanguageId).HasColumnName("LanguageId");
            this.Property(t => t.IsActive).HasColumnName("IsActive");
            this.Property(t => t.CreatedDate).HasColumnName("CreatedDate");
            this.Property(t => t.ModifiedDate).HasColumnName("ModifiedDate");
            this.Property(t => t.CreatedBy).HasColumnName("CreatedBy");
            this.Property(t => t.ModifiedBy).HasColumnName("ModifiedBy");

            // Relationships
            this.HasOptional(t => t.HTMLPage)
                .WithMany(t => t.HTMLPageContents)
                .HasForeignKey(d => d.HTMLPageId);
            this.HasOptional(t => t.Language)
                .WithMany(t => t.HTMLPageContents)
                .HasForeignKey(d => d.LanguageId);

        }
    }
}
