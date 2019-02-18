using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _365Plus.Service.Model
{
    public class CountryModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public long? DomainId { get; set; }
        public bool IsActive { get; set; }
		public long? NationalLanguageId { get; set; }
		public string NationalLanguageName { get; set; }
		public List<CountryLanguageModel> OtherLanguages { get;set;}
    }

    public class CountryLanguageModel
    {
        public long Id { get; set; }
        public long? CountryId { get; set; }
        public long? LanguageId { get; set; }
		public string LanguageName { get; set; }
		public bool  IsNationalLanguage { get; set; }
        public bool IsDefaultLanguage { get; set; }
    
       
    }
}
