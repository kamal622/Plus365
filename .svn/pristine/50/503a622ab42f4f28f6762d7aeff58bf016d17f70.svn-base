using System;
using System.Collections.Generic;
using _365Plus.Core;

namespace _365Plus.Data.Models
{
    public partial class UserSubscriptionStatu : BaseEntity
    {
        public Nullable<int> UserId { get; set; }
        public Nullable<long> EbookId { get; set; }
        public Nullable<int> Status { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
        public int CreatedBy { get; set; }
        public Nullable<int> ModifiedBy { get; set; }
        public Nullable<bool> IsActive { get; set; }
        public Nullable<decimal> Discount { get; set; }
        public virtual Ebook Ebook { get; set; }
    }
}
