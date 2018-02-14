using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HRIS_UIRevamp_v2.ViewModel
{
    public class WorkflowStatusOwnerCGSeriesViewModel
    {
        [Required]
        public string comp_id { get; set; }

        [Required]
        public string wflw_id { get; set; }

        [Required]
        public string status_id { get; set; }

        [Required]
        public string user_id { get; set; }

        [Required]
        public int cond_grp { get; set; }

        [Required]
        public int cond_grp_series { get; set; }

        public string cond { get; set; }

        public string table_id { get; set; }

        public string element { get; set; }

        public string operator1 { get; set; }

        public List<WorkflowStatusOwnerCGSValuesViewModel> workflowStatusCGSValues { get; set; }
    }
}