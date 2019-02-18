﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _365Plus.Service.Model
{
    public class EmailTemplateModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public long TemplateTypeId { get; set; }
        public string TemplateTypeName { get; set; }
        public long LanguageId { get; set; }
        public string LanguageName { get; set; }
        public bool IsActive { get; set; }
        //public DateTime? CreatedDate { get; set; }
        //public DateTime? ModifiedDate { get; set; }
        public int CreatedBy { get; set; }
        //public int? ModifiedBy { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public System.DateTime? ModifiedDate { get; set; }
        public Nullable<int> ModifiedBy { get; set; }
        public List<EmailTemplateTypeModel> Type { get; set; }
    }

    public class EmailTemplateTypeModel
    {
        public long Id { get; set; }
        public string Type { get; set; }
        public bool IsActive { get; set; }
    }
}
