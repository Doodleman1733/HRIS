using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HRIS_UIRevamp_v2.ViewModel
{
    public class EmployeeClassShiftViewModel
    {
        public string comp_id { get; set; }
        public string class_id { get; set; }
        public string sft_id { get; set; }
        public int? sequence { get; set; }
        public int? latefrom { get; set; }
        public int? lateto { get; set; }
        public bool allowtocomplete { get; set; }
        public string shiftrules { get; set; }
        public int? maxhours { get; set; }
        public bool allowovertime { get; set; }

    }

}