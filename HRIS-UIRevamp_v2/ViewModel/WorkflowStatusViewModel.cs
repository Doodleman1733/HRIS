using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HRIS_UIRevamp_v2.ViewModel
{
    public class WorkflowStatusViewModel
    {
        [Required]
        public string comp_id { get; set; }

        [Required]
        public string wflw_id { get; set; }

        [Required]
        public string status_id { get; set; }

        [Required]
        public string status1 { get; set; }

        [Required]
        public string status2 { get; set; }

        public bool endpoint { get; set; }

        public bool withremarks { get; set; }

        public List<WorkflowStatusOwnerViewModel> workflowStatusUser { get; set; }

        public List<WorkflowStatusFlowViewModel> workflowStatusFlow { get; set; }
    }
}