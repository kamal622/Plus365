using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _365Plus.Service.Model
{
    public class HtmlPagesModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Path { get; set; }
        public List<HtmlPageContentModel> HTMLContent { get; set; }
    }
    public class HtmlPageContentModel
	{
		public long Id { get; set; }
		public long? HTMLPageId { get; set; }
		 public string Name { get; set; }
        public string Path { get; set; }
        public string HTMLContent { get; set; }
        public long? LanguageId { get; set; }
        public bool IsActive { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public System.DateTime? ModifiedDate { get; set; }
        public int CreatedBy { get; set; }
        public int? ModifiedBy { get; set; }

    }
}
