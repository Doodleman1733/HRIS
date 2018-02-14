using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HRIS_UIRevamp_v2.ViewModel
{
    public class WorkflowStatusFlowViewModel
    {
        [Required]
        public string comp_id { get; set; }

        [Required]
        public string wflw_id { get; set; }

        [Required]
        public int id { get; set; }

        public string status_id_from { get; set; }

        public string status_id_to { get; set; }
    }
}