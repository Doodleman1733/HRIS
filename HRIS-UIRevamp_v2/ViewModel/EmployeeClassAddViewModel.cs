using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HRIS_UIRevamp_v2.ViewModel
{
    public class EmployeeClassAddViewModel
    {
        [StringLength(20)]
        [Required(ErrorMessage = "* Please select company")]
        [Display(Name = "Company")]
        public string comp_id { get; set; }

        [RegularExpression(@"^[a-zA-Z0-9_\-]{1,20}$", ErrorMessage = "Only allows A-Z, a-z, 0-9, _ and -")]
        [StringLength(20)]
        [Required(ErrorMessage = "* Please fill up Employee Class ID")]
        [Display(Name = "Employee Class ID")]
        [Remote("checkClassfExist", "Validation", AdditionalFields = "comp_id", ErrorMessage = "Duplicate Employee Class")]
        public string class_id { get; set; }

        [StringLength(50)]
        [Required(ErrorMessage = "* Please fill up Employee Class Name")]
        [Display(Name = "Employee Class Name")]
        public string name1 { get; set; }

        [StringLength(100)]
        [AllowHtml]
        [DataType(DataType.MultilineText)]
        [Display(Name = "Description")]
        public string description { get; set; }

        [Display(Name = "Monday")]
        public bool rdmonday { get; set; }

        [Display(Name = "Tuesday")]
        public bool rdtuesday { get; set; }

        [Display(Name = "Wednesday")]
        public bool rdwednesday { get; set; }

        [Display(Name = "Thursday")]
        public bool rdthursday { get; set; }

        [Display(Name = "Friday")]
        public bool rdfriday { get; set; }

        [Display(Name = "Saturday")]
        public bool rdsaturday { get; set; }

        [Display(Name = "Sunday")]
        public bool rdsunday { get; set; }

        [Required(ErrorMessage = "* Monday Shift is required")]
        [Display(Name = "Monday Shift")]
        public string shiftmonday { get; set; }

        [Required(ErrorMessage = "* Tuesday Shift is required")]
        [Display(Name = "Tuesday Shift")]
        public string shifttuesday { get; set; }

        [Required(ErrorMessage = "* Wednesday Shift is required")]
        [Display(Name = "Wednesday Shift")]
        public string shiftwednesday { get; set; }

        [Required(ErrorMessage = "* Thursday Shift is required")]
        [Display(Name = "Thursday Shift")]
        public string shiftthursday { get; set; }

        [Required(ErrorMessage = "* Friday Shift is required")]
        [Display(Name = "Friday Shift")]
        public string shiftfriday { get; set; }

        [Required(ErrorMessage = "* Saturday Shift is required")]
        [Display(Name = "Saturday Shift")]
        public string shiftsaturday { get; set; }

        [Required(ErrorMessage = "* Sunday Shift is required")]
        [Display(Name = "Sunday Shift")]
        public string shiftsunday { get; set; }

        public bool overridemonday { get; set; }
        public TimeSpan? minvaluemonday { get; set; }
        public TimeSpan? intovaluemonday { get; set; }

        public bool overridetuesday { get; set; }
        public TimeSpan? minvaluetuesday { get; set; }
        public TimeSpan? intovaluetuesday { get; set; }

        public bool overridewednesday { get; set; }
        public TimeSpan? minvaluewednesday { get; set; }
        public TimeSpan? intovaluewednesday { get; set; }

        public bool overridethursday { get; set; }
        public TimeSpan? minvaluethursday { get; set; }
        public TimeSpan? intovaluethursday { get; set; }

        public bool overridefriday { get; set; }
        public TimeSpan? minvaluefriday { get; set; }
        public TimeSpan? intovaluefriday { get; set; }

        public bool overridesaturday { get; set; }
        public TimeSpan? minvaluesaturday { get; set; }
        public TimeSpan? intovaluesaturday { get; set; }

        public bool overridesunday { get; set; }
        public TimeSpan? minvaluesunday { get; set; }
        public TimeSpan? intovaluesunday { get; set; }

        [Display(Name = "Acceptable Time In Margin (in minutes)")]
        public int? shiftinmargin { get; set; }

        [Display(Name = "Default Shift Round Down (in minutes)")]
        public int? shiftroundown { get; set; }

        [Display(Name = "Default Overtime Round Down (in minutes)")]
        public int? otrounddown { get; set; }

        [Display(Name = "Maximum Allowable Hour in a Day")]
        public int? maximumallowablehours { get; set; }

        [Display(Name = "Cut-off Period")]
        public string cutoffperiod { get; set; }

        [Display(Name = "Bypass Shift Rules?")]
        public bool bypassshiftrules { get; set; }

        [Display(Name = "Allow Overtime?")]
        public bool allowovertime { get; set; }

        [Display(Name = "Automatic Pay for Legal Holiday?")]
        public bool regholidaypaid { get; set; }

        [Display(Name = "Automatic Pay for Special Holiday?")]
        public bool specholidaypaid { get; set; }

        [Display(Name = "Automatic count of Basic Hours when Legal Holiday falls on a Rest day?")]
        public bool regholidaypaidonrestday { get; set; }

        [Display(Name = "Special Holiday")]
        public decimal? specholidaymultiplier { get; set; }

        [Display(Name = "Legal Holiday")]
        public decimal? regholidaymultiplier { get; set; }

        [Display(Name = "Double Holiday")]
        public decimal? doubleholidaymulplier { get; set; }

        [Display(Name = "Regular day Overtime")]
        public decimal? regotmultiplier { get; set; }

        [Display(Name = "Non-regular day Overtime")]
        public decimal? nonregotmultiplier { get; set; }

        [Display(Name = "Rest Day")]
        public decimal? restdaymultiplier { get; set; }

        [DisplayFormat(DataFormatString = "{0:#.##%}")]
        [Display(Name = "Night Differential")]
        public decimal? nightdiffmultiplier { get; set; }

        [Display(Name = "Minimum HOUR/s?")]
        public int minothours { get; set; }

        [Display(Name = "OT Break Rules")]
        public string otrule { get; set; }

        [Display(Name = "Minimum HOUR/s?")]
        public int automin1 { get; set; }

        [Display(Name = "Minimum HOUR/s?")]
        public int automin2 { get; set; }

        [Display(Name = "Minimum HOUR/s?")]
        public int autohours2 { get; set; }

        [Display(Name = "Minimum HOUR/s?")]
        public int automin3 { get; set; }

        [Display(Name = "Minimum HOUR/s?")]
        public int autohours3 { get; set; }

        public TimeSpan? fixtimefrom { get; set; }
        public TimeSpan? fixtimeto { get; set; }

        [Display(Name = "Active")]
        public bool active { get; set; }

        public DateTime createdDateTime { get; set; }

        public string createdBy { get; set; }

        public List<EmployeeClassShiftViewModel> ClassShift { get; set; }
        
        public List<EmployeeClassShiftRulesViewModel> ClassShiftRules { get; set; }
    }
}