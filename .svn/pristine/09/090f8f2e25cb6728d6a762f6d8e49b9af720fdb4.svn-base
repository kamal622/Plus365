using System;
using System.Collections.Generic;
using _365Plus.Core;

namespace _365Plus.Data.Models
{
    public partial class Ebook : BaseEntity
    {
        public Ebook()
        {
            this.UserSubscriptionStatus = new List<UserSubscriptionStatu>();
        }

        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public virtual ICollection<UserSubscriptionStatu> UserSubscriptionStatus { get; set; }
    }
}
