using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HRIS_UIRevamp_v2.ViewModel
{
    public class WorkflowStatusOwnerCGSValuesViewModel
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

        [Required]
        public int value_series { get; set; }

        [Required]
        public string value { get; set; }
    }
}