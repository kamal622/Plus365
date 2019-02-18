using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _365Plus.Service.Model
{
    public class LanguageModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Culture { get; set; }
        public bool IsActive { get; set; }
    }
}
