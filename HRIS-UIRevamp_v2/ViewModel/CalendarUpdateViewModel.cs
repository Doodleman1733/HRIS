using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HRIS_UIRevamp_v2.ViewModel
{
    public class CalendarUpdateViewModel
    {
        public long cal_id { get; set; }

        [StringLength(50)]
        [Required]
        [Display(Name = "Title")]
        public string name1 { get; set; }

        [StringLength(100)]
        [DataType(DataType.MultilineText)]
        [Display(Name = "Description")]
        public string description { get; set; }

        [Display(Name = "Legal Holiday")]
        public bool regholiday { get; set; }

        [Display(Name = "Special Holiday")]
        public bool specholiday { get; set; }

        [Required]
        [Display(Name = "Event Period")]
        public string eventPeriod { get; set; }

        public bool active { get; set; }

        public DateTime? modifiedDateTime { get; set; }

        public string modifiedBy { get; set; }

        public string[] company { get; set; }

        public string upCompanies { get; set; }

        public List<CalendarCompanySetup> companies { get; set; }

    }
}