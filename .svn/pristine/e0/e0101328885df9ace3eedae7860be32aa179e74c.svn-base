using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace _365Plus.Data.Models.Mapping
{
    public class CountryLanguageMap : EntityTypeConfiguration<CountryLanguage>
    {
        public CountryLanguageMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            // Table & Column Mappings
            this.ToTable("CountryLanguages");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.CountryId).HasColumnName("CountryId");
            this.Property(t => t.LanguageId).HasColumnName("LanguageId");
            this.Property(t => t.IsNationalLanguage).HasColumnName("IsNationalLanguage");
            this.Property(t => t.IsDefaultLanguage).HasColumnName("IsDefaultLanguage");

            // Relationships
            this.HasOptional(t => t.Country)
                .WithMany(t => t.CountryLanguages)
                .HasForeignKey(d => d.CountryId);
            this.HasOptional(t => t.Language)
                .WithMany(t => t.CountryLanguages)
                .HasForeignKey(d => d.LanguageId);

        }
    }
}
