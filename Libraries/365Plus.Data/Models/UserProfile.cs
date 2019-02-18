using System;
using System.Collections.Generic;
using _365Plus.Core;

namespace _365Plus.Data.Models
{
    public partial class UserProfile : BaseEntity
    {
        public UserProfile()
        {
            this.Users = new List<User>();
        }
        public new int Id { get; set; }
        public bool IsActive { get; set; }
        public bool IsBlocked { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool IsVersionUpdated { get; set; }
        public string UserCode { get; set; }
        public string PersonalEmail { get; set; }
        public Nullable<long> CountryId { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
        public Nullable<int> CreatedBy { get; set; }
        public Nullable<int> ModifiedBy { get; set; }
        public Nullable<long> LanguageId { get; set; }
        public string MobileNo { get; set; }
        public Nullable<System.DateTime> DateOfBirth { get; set; }
        public string Status { get; set; }
        public Nullable<decimal> Points { get; set; }
        public Nullable<decimal> TotalPaidAmount { get; set; }
        public string ReferralCode { get; set; }
        public Nullable<int> ParentId { get; set; }
        public string PromotionCode { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
}
