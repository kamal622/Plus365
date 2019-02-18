using System;
using System.Collections.Generic;
using _365Plus.Core;

namespace _365Plus.Data.Models
{
    public partial class HTMLPageContent : BaseEntity
    {
        public Nullable<long> HTMLPageId { get; set; }
        public string HTMLContent { get; set; }
        public Nullable<long> LanguageId { get; set; }
        public bool IsActive { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
        public int CreatedBy { get; set; }
        public Nullable<int> ModifiedBy { get; set; }
        public virtual HTMLPage HTMLPage { get; set; }
        public virtual Language Language { get; set; }
    }
}
