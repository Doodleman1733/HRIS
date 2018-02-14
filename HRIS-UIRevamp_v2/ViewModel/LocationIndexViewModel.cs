using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HRIS_UIRevamp_v2.ViewModel
{
    public class LocationIndexViewModel : dTableSettings
    {
        [Display(Name = "Company")]
        public string comp_id { get; set; }

        [Display(Name = "Location ID")]
        public string loc_id { get; set; }

        [Display(Name = "Location Name")]
        public string name1 { get; set; }
    }
}