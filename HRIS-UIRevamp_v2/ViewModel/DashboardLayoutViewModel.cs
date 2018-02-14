using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HRIS_UIRevamp_v2.ViewModel
{
    public class DashboardLayoutViewModel
    {
        public string layout_id { get; set; }

        public string widget_id { get; set; }

        public int positiontop { get; set; }

        public int positionleft { get; set; }

        public string url { get; set; }
    }
}