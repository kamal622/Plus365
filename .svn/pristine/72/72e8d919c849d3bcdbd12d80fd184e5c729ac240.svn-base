using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace _365Plus.Data.Models.Mapping
{
    public class HTMLPageMap : EntityTypeConfiguration<HTMLPage>
    {
        public HTMLPageMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Name)
                .HasMaxLength(250);

            this.Property(t => t.Path)
                .HasMaxLength(500);

            // Table & Column Mappings
            this.ToTable("HTMLPage");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.Path).HasColumnName("Path");
        }
    }
}
