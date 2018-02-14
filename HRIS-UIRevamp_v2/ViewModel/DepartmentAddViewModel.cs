using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HRIS_UIRevamp_v2.ViewModel
{
    public class DepartmentAddViewModel
    {

        [StringLength(20)]
        [Required]
        [Display(Name = "Company")]
        public string comp_id { get; set; }

        [StringLength(20)]
        [Required]
        [Display(Name = "Division")]
        public string div_id { get; set; }

        [RegularExpression(@"^[a-zA-Z0-9_\-]{1,20}$", ErrorMessage = "Only allows A-Z, a-z, 0-9, _ and -")]
        [StringLength(20)]
        [Required]
        [Display(Name = "Department ID")]
        public string dept_id { get; set; }

        [StringLength(50)]
        [Required]
        [Display(Name = "Department Name")]
        public string name1 { get; set; }

        [StringLength(100)]
        [AllowHtml]
        [DataType(DataType.MultilineText)]
        [Display(Name = "Additional Information")]
        public string description { get; set; }

        public bool active { get; set; }

        public DateTime createdDatetime { get; set; }

        public string createdBy { get; set; }

        public List<SectionAddViewModel> sections { get; set; }
    }
}