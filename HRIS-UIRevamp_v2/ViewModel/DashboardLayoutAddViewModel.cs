using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HRIS_UIRevamp_v2.ViewModel
{
    public class DashboardLayoutAddViewModel
    {
        [Required]
        public string layout_id { get; set; }

        public string name1 { get; set; }

        public string description { get; set; }

        public string type { get; set; }

        public bool access_type { get; set; }

        public bool active { get; set; }

        public DateTime createdDateTime { get; set; }
        
        public string createdBy { get; set; }

        public List<DashboardLayoutViewModel> DashboardWidgetSetup { get; set; }
    }
}