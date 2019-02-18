using System;
using System.Collections.Generic;
using _365Plus.Core;

namespace _365Plus.Data.Models
{
    public partial class Role : BaseEntity
    {
        public Role()
        {
            this.Users = new List<User>();
        }
        public new int Id { get; set; }
        public string Name { get; set; }
        public Nullable<int> RoleProfile_Id { get; set; }
        public virtual RoleProfile RoleProfile { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
}
