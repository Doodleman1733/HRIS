using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HRIS_UIRevamp_v2.ViewModel
{
    public class DivisionIndexViewModel : dTableSettings
    {
        [Display(Name = "Division ID")]
        public string div_id { get; set; }

        [Display(Name = "Company")]
        public string comp_id { get; set; }
    }
}