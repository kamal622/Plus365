using System;
using System.Collections.Generic;
using _365Plus.Core;

namespace _365Plus.Data.Models
{
    public partial class CountryLanguage : BaseEntity
    {
        public Nullable<long> CountryId { get; set; }
        public Nullable<long> LanguageId { get; set; }
        public bool IsNationalLanguage { get; set; }
        public bool IsDefaultLanguage { get; set; }
        public virtual Country Country { get; set; }
        public virtual Language Language { get; set; }
    }
}
