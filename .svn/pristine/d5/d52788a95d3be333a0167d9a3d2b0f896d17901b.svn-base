using System;
using System.Collections.Generic;
using _365Plus.Core;

namespace _365Plus.Data.Models
{
    public partial class DomainDetail : BaseEntity
    {
        public DomainDetail()
        {
            this.Countries = new List<Country>();
        }

        public string Name { get; set; }
        public string Domain { get; set; }
        public virtual ICollection<Country> Countries { get; set; }
    }
}
