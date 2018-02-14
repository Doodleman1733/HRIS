using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HRIS_UIRevamp_v2.ViewModel
{
    public class DocumentNumberIndexViewModel : dTableSettings
    {
        [Display(Name = "Company ID")]
        [StringLength(20)]
        public string comp_id { get; set; }

        [Display(Name = "Document ID")]
        [StringLength(5)]
        public string doc_id { get; set; }

        [Display(Name = "Document Name")]
        [StringLength(50)]
        public string name1 { get; set; }
    }
}