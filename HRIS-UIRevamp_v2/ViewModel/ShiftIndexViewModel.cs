using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HRIS_UIRevamp_v2.ViewModel
{
    public class ShiftIndexViewModel : dTableSettings
    {
        [Display(Name = "Company")]
        public string comp_id { get; set; }

        [Display(Name = "Shift ID")]
        public string sft_Id { get; set; }

        [Display(Name = "Shift Name")]
        public string name1 { get; set; }
    }
}