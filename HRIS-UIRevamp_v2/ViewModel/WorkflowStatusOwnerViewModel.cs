using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HRIS_UIRevamp_v2.ViewModel
{
    public class WorkflowStatusOwnerViewModel
    {
        [Required]
        public string comp_id { get; set; }

        [Required]
        public string wflw_id { get; set; }

        [Required]
        public string status_id { get; set; }

        [Required]
        public string user_id { get; set; }

        public bool edit { get; set; }

        public List<WorkflowStatusOwnerCGroupViewModel> workflowStatusOwnerCG { get; set; }
    }
}