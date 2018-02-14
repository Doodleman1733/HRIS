using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HRIS_UIRevamp_v2.ViewModel
{
    public class CalendarIndexViewModel : dTableSettings
    {
        [Display(Name = "Date Range")]
        public string DateRange { get; set; }
    }
}