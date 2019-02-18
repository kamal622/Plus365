using System;
using System.Collections.Generic;
using _365Plus.Core;

namespace _365Plus.Data.Models
{
    public partial class Localization : BaseEntity
    {
        public int pk { get; set; }
        public string ResourceId { get; set; }
        public string Value { get; set; }
        public string LocaleId { get; set; }
        public string ResourceSet { get; set; }
        public string Type { get; set; }
        public byte[] BinFile { get; set; }
        public string TextFile { get; set; }
        public string Filename { get; set; }
        public string Comment { get; set; }
        public int ValueType { get; set; }
        public Nullable<System.DateTime> Updated { get; set; }
    }
}
