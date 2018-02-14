using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HRIS_UIRevamp_v2.ViewModel
{
    public class WorkflowIndexViewModel : dTableSettings
    {
        [Display(Name = "Company")]
        public string comp_id { get; set; }

        [Display(Name = "Workflow")]
        public string wflw_id { get; set; }

        [Display(Name = "Module")]
        public string module_id { get; set; }
    }
}