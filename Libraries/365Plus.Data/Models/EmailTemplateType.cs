using System;
using System.Collections.Generic;
using _365Plus.Core;

namespace _365Plus.Data.Models
{
    public partial class EmailTemplateType : BaseEntity
    {
        public EmailTemplateType()
        {
            this.EmailTemplates = new List<EmailTemplate>();
        }

        public string Type { get; set; }
        public bool IsActive { get; set; }
        public virtual ICollection<EmailTemplate> EmailTemplates { get; set; }
    }
}
