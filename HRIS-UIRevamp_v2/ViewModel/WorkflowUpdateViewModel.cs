using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HRIS_UIRevamp_v2.ViewModel
{
    public class WorkflowUpdateViewModel
    {
        [StringLength(20)]
        [Required(ErrorMessage = "* Please Select Company")]
        [Display(Name = "Company")]
        public string comp_id { get; set; }

        [RegularExpression(@"^[a-zA-Z0-9_\-]{1,20}$", ErrorMessage = "Only allows A-Z, a-z, 0-9, _ and -")]
        [StringLength(20)]
        [Required(ErrorMessage = "* Please fill up Worlflow ID")]
        [Display(Name = "Worlflow ID")]
        public string wflw_id { get; set; }

        [Display(Name = "Worlflow Name")]
        public string name1 { get; set; }

        [Display(Name = "Module")]
        public string module_id { get; set; }

        [Display(Name = "Active")]
        public bool active { get; set; }

        public DateTime modifiedDateTime { get; set; }

        public string modifiedBy { get; set; }

        public List<WorkflowStatusViewModel> WorkflowStatus { get; set; }
    }
}