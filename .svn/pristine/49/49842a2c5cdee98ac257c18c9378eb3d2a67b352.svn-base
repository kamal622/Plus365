using System;
using System.Collections.Generic;
using _365Plus.Core;

namespace _365Plus.Data.Models
{
    public partial class Country : BaseEntity
    {
        public Country()
        {
            this.CountryLanguages = new List<CountryLanguage>();
        }

        public string Name { get; set; }
        public Nullable<long> DomainId { get; set; }
        public bool IsActive { get; set; }
        public virtual DomainDetail DomainDetail { get; set; }
        public virtual ICollection<CountryLanguage> CountryLanguages { get; set; }
    }
}
