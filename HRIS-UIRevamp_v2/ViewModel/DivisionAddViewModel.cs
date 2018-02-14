using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HRIS_UIRevamp_v2.ViewModel
{
    public class DivisionAddViewModel
    {
        [StringLength(20)]
        [Required(ErrorMessage = "* Please Select Company")]
        [Display(Name = "Company")]
        public string comp_id { get; set; }

        [RegularExpression(@"^[a-zA-Z0-9_\-]{1,20}$", ErrorMessage = "Only allows A-Z, a-z, 0-9, _ and -")]
        [StringLength(20)]
        [Required(ErrorMessage = "* Please fill up Division ID")]
        [Display(Name = "Division ID")]
        [Remote("CheckDivisionIfExist", "Validation", AdditionalFields = "comp_id", ErrorMessage = "* Duplicate Division")]
        public string div_id { get; set; }

        [StringLength(50)]
        [Required(ErrorMessage = "* Please fill up Division Name")]
        [Display(Name = "Division Name")]
        public string name1 { get; set; }

        [StringLength(1000)]
        [Display(Name = "Additional Information")]
        [AllowHtml]
        public string description { get; set; }
        
        public bool active { get; set; }
        
        public DateTime createdDatetime { get; set; }
        
        public string createdBy { get; set; }

        public List<DepartmentAddViewModel> departments { get; set; }

        [RegularExpression(@"^[a-zA-Z0-9_\-]{1,20}$", ErrorMessage = "* Only allows A-Z, a-z, 0-9, _ and -")]
        public string dept_id { get; set; }

        [StringLength(50)]
        public string dept_name1 { get; set; }

        [StringLength(100)]
        public string dept_description { get; set; }

        [RegularExpression(@"^[a-zA-Z0-9_\-]{1,20}$", ErrorMessage = "* Only allows A-Z, a-z, 0-9, _ and -")]
        public string sect_id { get; set; }

        [StringLength(50)]
        public string sect_name1 { get; set; }

        [StringLength(100)]
        public string sect_description { get; set; }
    }
}