using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace _365Plus.Data.Models.Mapping
{
    public class RoleProfileMap : EntityTypeConfiguration<RoleProfile>
    {
        public RoleProfileMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            // Table & Column Mappings
            this.ToTable("RoleProfiles");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.RoleDescription).HasColumnName("RoleDescription");
            this.Property(t => t.RoleCode).HasColumnName("RoleCode");
        }
    }
}
