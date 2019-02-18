using System;
using System.Collections.Generic;
using _365Plus.Core;

namespace _365Plus.Data.Models
{
    public partial class Setting : BaseEntity
    {
        public string Name { get; set; }
        public string Value { get; set; }
    }
}
