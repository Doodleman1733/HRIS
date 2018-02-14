using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HRIS_UIRevamp_v2.ViewModel
{
    public class CalendarResultViewModel
    {
        [Display(Name = "Title")]
        public string name1 { get; set; }

        [Display(Name = "Description")]
        public string description { get; set; }

        [Display(Name = "Regular Holiday")]
        public bool regholiday { get; set; }

        [Display(Name = "Special Holiday")]
        public bool specholiday { get; set; }



        public DateTime? eventfrom { get; set; }
        public DateTime? eventto { get; set; }
        public bool active { get; set; }
        public DateTime createdDateTime { get; set; }
        public long? RowNum { get; set; }
        public long cal_id { get; set; }

        [Display(Name = "Event Period")]
        public string eventPeriod { get; set; }

        [Display(Name = "All Companies")]
        public bool company { get; set; }

        [Display(Name = "Company")]
        public string comp { get; set; }
    }
}