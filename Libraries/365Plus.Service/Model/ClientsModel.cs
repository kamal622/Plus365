﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _365Plus.Service.Model
{
   public class ClientsModel
    {

        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PersonalEmail { get; set; }

        public string MobileNo { get; set; }
        public Nullable<System.DateTime> DateOfBirth { get; set; }
        public string UserCode { get; set; }
        public long? CountryId { get; set; }
        public string CountryName { get; set; }
        public string ReferralCode { get; set; }
        public string PromotionCode { get; set; }
        public bool IsActive { get; set; }
        public bool IsBlocked { get; set; }
        public System.DateTime? CreatedDate { get; set; }
        public System.DateTime? ModifiedDate { get; set; }
        public int? CreatedBy { get; set; }
        public int? ModifiedBy { get; set; }
        public long? LanguageId { get; set; }
        public string LanguageName { get; set; }
        public int RoleId { get; set; }
        public string RoleName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }

    }

    public class UserSubscriptionStatusModel
    {
        public long Id { get; set; }
        public Nullable<int> UserId { get; set; }
        public Nullable<long> EbookId { get; set; }
        public string EbookTitle { get; set; }
        public Nullable<int> Status { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
        public int CreatedBy { get; set; }
        public Nullable<int> ModifiedBy { get; set; }
        public Nullable<bool> IsActive { get; set; }
        public Nullable<decimal> Discount { get; set; }
    }
}
