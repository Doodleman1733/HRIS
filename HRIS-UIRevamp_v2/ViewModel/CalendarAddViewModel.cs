using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HRIS_UIRevamp_v2.ViewModel
{
    public class CalendarAddViewModel
    {
        [StringLength(50)]
        [Required(ErrorMessage = "* Please fill up Activity Title")]
        [Display(Name = "Title")]
        public string name1 { get; set; }

        [StringLength(100)]
        [DataType(DataType.MultilineText)]
        [Display(Name = "Description")]
        public string description { get; set; }

        [Required]
        [Display(Name = "Legal Holiday")]
        public bool regholiday { get; set; }

        [Required]
        [Display(Name = "Special Holiday")]
        public bool specholiday { get; set; }

        [Required(ErrorMessage = "* Please fill up Event Period")]
        [Display(Name = "Event Period")]
        public string eventPeriod { get; set; }

        public bool active { get; set; }
        
        public DateTime createdDateTime { get; set; }
        
        public string createdBy { get; set; }

        public List<CalendarCompanySetup> companies { get; set; }

    }
}