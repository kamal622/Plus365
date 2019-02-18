using System;
using System.Collections.Generic;
using _365Plus.Core;

namespace _365Plus.Data.Models
{
    public partial class Language : BaseEntity
    {
        public Language()
        {
            this.CountryLanguages = new List<CountryLanguage>();
            this.EmailTemplates = new List<EmailTemplate>();
            this.HTMLPageContents = new List<HTMLPageContent>();
        }

        public string Name { get; set; }
        public string Culture { get; set; }
        public bool IsActive { get; set; }
        public virtual ICollection<CountryLanguage> CountryLanguages { get; set; }
        public virtual ICollection<EmailTemplate> EmailTemplates { get; set; }
        public virtual ICollection<HTMLPageContent> HTMLPageContents { get; set; }
    }
}
