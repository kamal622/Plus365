using System;
using System.Collections.Generic;
using _365Plus.Core;

namespace _365Plus.Data.Models
{
    public partial class RoleProfile : BaseEntity
    {
        public RoleProfile()
        {
            this.Roles = new List<Role>();
        }
        public new int Id { get; set; }
        public string RoleDescription { get; set; }
        public string RoleCode { get; set; }
        public virtual ICollection<Role> Roles { get; set; }
    }
}
