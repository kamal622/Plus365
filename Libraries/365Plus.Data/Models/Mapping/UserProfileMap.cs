using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace _365Plus.Data.Models.Mapping
{
    public class UserProfileMap : EntityTypeConfiguration<UserProfile>
    {
        public UserProfileMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.UserCode)
                .HasMaxLength(500);

            this.Property(t => t.PersonalEmail)
                .HasMaxLength(50);

            this.Property(t => t.MobileNo)
                .HasMaxLength(50);

            this.Property(t => t.Status)
                .HasMaxLength(50);

            this.Property(t => t.ReferralCode)
                .HasMaxLength(500);

            this.Property(t => t.PromotionCode)
                .HasMaxLength(500);

            // Table & Column Mappings
            this.ToTable("UserProfile");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.IsActive).HasColumnName("IsActive");
            this.Property(t => t.IsBlocked).HasColumnName("IsBlocked");
            this.Property(t => t.FirstName).HasColumnName("FirstName");
            this.Property(t => t.LastName).HasColumnName("LastName");
            this.Property(t => t.IsVersionUpdated).HasColumnName("IsVersionUpdated");
            this.Property(t => t.UserCode).HasColumnName("UserCode");
            this.Property(t => t.PersonalEmail).HasColumnName("PersonalEmail");
            this.Property(t => t.CountryId).HasColumnName("CountryId");
            this.Property(t => t.CreatedDate).HasColumnName("CreatedDate");
            this.Property(t => t.ModifiedDate).HasColumnName("ModifiedDate");
            this.Property(t => t.CreatedBy).HasColumnName("CreatedBy");
            this.Property(t => t.ModifiedBy).HasColumnName("ModifiedBy");
            this.Property(t => t.LanguageId).HasColumnName("LanguageId");
            this.Property(t => t.MobileNo).HasColumnName("MobileNo");
            this.Property(t => t.DateOfBirth).HasColumnName("DateOfBirth");
            this.Property(t => t.Status).HasColumnName("Status");
            this.Property(t => t.Points).HasColumnName("Points");
            this.Property(t => t.TotalPaidAmount).HasColumnName("TotalPaidAmount");
            this.Property(t => t.ReferralCode).HasColumnName("ReferralCode");
            this.Property(t => t.ParentId).HasColumnName("ParentId");
            this.Property(t => t.PromotionCode).HasColumnName("PromotionCode");
        }
    }
}
