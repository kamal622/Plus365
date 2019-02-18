using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace _365Plus.Data.Models.Mapping
{
    public class Localizations_BackupMap : EntityTypeConfiguration<Localizations_Backup>
    {
        public Localizations_BackupMap()
        {
            // Primary Key
            this.HasKey(t => new { t.pk, t.ResourceId, t.ValueType });

            // Properties
            this.Property(t => t.pk)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            this.Property(t => t.ResourceId)
                .IsRequired()
                .HasMaxLength(1024);

            this.Property(t => t.LocaleId)
                .HasMaxLength(10);

            this.Property(t => t.ResourceSet)
                .HasMaxLength(512);

            this.Property(t => t.Type)
                .HasMaxLength(512);

            this.Property(t => t.Filename)
                .HasMaxLength(128);

            this.Property(t => t.Comment)
                .HasMaxLength(512);

            this.Property(t => t.ValueType)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            // Table & Column Mappings
            this.ToTable("Localizations_Backup");
            this.Property(t => t.pk).HasColumnName("pk");
            this.Property(t => t.ResourceId).HasColumnName("ResourceId");
            this.Property(t => t.Value).HasColumnName("Value");
            this.Property(t => t.LocaleId).HasColumnName("LocaleId");
            this.Property(t => t.ResourceSet).HasColumnName("ResourceSet");
            this.Property(t => t.Type).HasColumnName("Type");
            this.Property(t => t.BinFile).HasColumnName("BinFile");
            this.Property(t => t.TextFile).HasColumnName("TextFile");
            this.Property(t => t.Filename).HasColumnName("Filename");
            this.Property(t => t.Comment).HasColumnName("Comment");
            this.Property(t => t.ValueType).HasColumnName("ValueType");
            this.Property(t => t.Updated).HasColumnName("Updated");
        }
    }
}
