using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HRIS_UIRevamp_v2.ViewModel
{
    public class DivisionUpdateViewModel
    {
        [StringLength(20)]
        [Required]
        [Display(Name = "Company")]
        public string comp_id { get; set; }

        [RegularExpression(@"^[a-zA-Z0-9_\-]{1,20}$", ErrorMessage = "Only allows A-Z, a-z, 0-9, _ and -")]
        [StringLength(20)]
        [Required]
        [Display(Name = "Division ID")]
        public string div_id { get; set; }

        [StringLength(50)]
        [Required]
        [Display(Name = "Division Name")]
        public string name1 { get; set; }

        [StringLength(100)]
        [AllowHtml]
        [Display(Name = "Additional Information")]
        public string description { get; set; }
        
        public bool active { get; set; }
        
        public DateTime? modifiedDatetime { get; set; }
        
        public string modifiedBy { get; set; }

        public List<DepartmentUpdateViewModel> departments { get; set; }

        [RegularExpression(@"^[a-zA-Z0-9_\-]{1,20}$", ErrorMessage = "* Only allows A-Z, a-z, 0-9, _ and -")]
        public string dept_id { get; set; }

        public string dept_name1 { get; set; }

        public string dept_description { get; set; }

        [RegularExpression(@"^[a-zA-Z0-9_\-]{1,20}$", ErrorMessage = "* Only allows A-Z, a-z, 0-9, _ and -")]
        public string sect_id { get; set; }

        public string sect_name1 { get; set; }

        public string sect_description { get; set; }
    }
}