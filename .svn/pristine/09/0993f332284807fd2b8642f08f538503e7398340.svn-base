using System;
using System.Collections.Generic;
using _365Plus.Core;

namespace _365Plus.Data.Models
{
    public partial class EmailTemplate : BaseEntity
    {
        public string Name { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public long TemplateTypeId { get; set; }
        public long LanguageId { get; set; }
        public bool IsActive { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
        public int CreatedBy { get; set; }
        public Nullable<int> ModifiedBy { get; set; }
        public virtual EmailTemplateType EmailTemplateType { get; set; }
        public virtual Language Language { get; set; }
    }
}
