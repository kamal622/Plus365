using System;
using System.Collections.Generic;
using _365Plus.Core;

namespace _365Plus.Data.Models
{
    public partial class UserLogin : BaseEntity
    {
        public string LoginProvider { get; set; }
        public string ProviderKey { get; set; }
        public int UserId { get; set; }
        public virtual User User { get; set; }
    }
}
