using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HRIS_UIRevamp_v2.ViewModel
{
    public class EmployeeClassShiftRulesViewModel
    {
        [Required]
        public string comp_id { get; set; }

        [Required]
        public string class_id { get; set; }

        [Required]
        public string sft_id { get; set; }

        public int? minothours { get; set; }

        [Required]
        public string otrule { get; set; }

        public int? automin1 { get; set; }

        public int? automin2 { get; set; }

        public int? autohours2 { get; set; }

        public int? automin3 { get; set; }

        public int? autohours3 { get; set; }

        public TimeSpan? fixtimefrom { get; set; }

        public TimeSpan? fixtimeto { get; set; }
    }
}