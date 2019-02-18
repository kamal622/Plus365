using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace _365Plus.Data.Models.Mapping
{
    public class UserSubscriptionStatuMap : EntityTypeConfiguration<UserSubscriptionStatu>
    {
        public UserSubscriptionStatuMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            // Table & Column Mappings
            this.ToTable("UserSubscriptionStatus");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.UserId).HasColumnName("UserId");
            this.Property(t => t.EbookId).HasColumnName("EbookId");
            this.Property(t => t.Status).HasColumnName("Status");
            this.Property(t => t.CreatedDate).HasColumnName("CreatedDate");
            this.Property(t => t.ModifiedDate).HasColumnName("ModifiedDate");
            this.Property(t => t.CreatedBy).HasColumnName("CreatedBy");
            this.Property(t => t.ModifiedBy).HasColumnName("ModifiedBy");
            this.Property(t => t.IsActive).HasColumnName("IsActive");
            this.Property(t => t.Discount).HasColumnName("Discount");

            // Relationships
            this.HasOptional(t => t.Ebook)
                .WithMany(t => t.UserSubscriptionStatus)
                .HasForeignKey(d => d.EbookId);

        }
    }
}
