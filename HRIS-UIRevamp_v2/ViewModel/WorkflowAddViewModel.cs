using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HRIS_UIRevamp_v2.ViewModel
{
    public class WorkflowAddViewModel
    {
        [StringLength(20)]
        [Required(ErrorMessage = "* Please Select Company")]
        [Display(Name = "Company")]
        public string comp_id { get; set; }

        [RegularExpression(@"^[a-zA-Z0-9_\-]{1,20}$", ErrorMessage = "Only allows A-Z, a-z, 0-9, _ and -")]
        [StringLength(20)]
        [Required(ErrorMessage = "* Please fill up Worlflow ID")]
        [Display(Name = "Worlflow ID")]
        [Remote("CheckWorkflowIfExist", "Validation", AdditionalFields = "comp_id", ErrorMessage = "* Duplicate Worlflow ID")]
        public string wflw_id { get; set; }

        [Display(Name = "Worlflow Name")]
        public string name1 { get; set; }

        [Display(Name = "Module")]
        public string module_id { get; set; }
        
        [Display(Name = "Active")]
        public bool active { get; set; }
        
        public DateTime createdDateTime { get; set; }
        
        public string createdBy { get; set; }

        public List<WorkflowStatusViewModel> WorkflowStatus { get; set; }
    }
}