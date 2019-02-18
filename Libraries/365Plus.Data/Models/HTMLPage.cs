using System;
using System.Collections.Generic;
using _365Plus.Core;

namespace _365Plus.Data.Models
{
    public partial class HTMLPage : BaseEntity
    {
        public HTMLPage()
        {
            this.HTMLPageContents = new List<HTMLPageContent>();
        }

        public string Name { get; set; }
        public string Path { get; set; }
        public virtual ICollection<HTMLPageContent> HTMLPageContents { get; set; }
    }
}
