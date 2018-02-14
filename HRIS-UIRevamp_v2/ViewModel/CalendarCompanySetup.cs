using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HRIS_UIRevamp_v2.ViewModel
{
    public class CalendarCompanySetup
    {
        public string comp_id { get; set; }
        public DateTime createdDateTime { get; set; }
        public string createdBy { get; set; }
        public DateTime? modifiedDateTime { get; set; }
        public string modifiedBy { get; set; }
    }
}