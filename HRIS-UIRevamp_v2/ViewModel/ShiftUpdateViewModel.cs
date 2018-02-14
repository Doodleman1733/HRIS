using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HRIS_UIRevamp_v2.ViewModel
{
    public class ShiftUpdateViewModel
    {
        [StringLength(20)]
        [Required(ErrorMessage = "* Please Select Company")]
        [Display(Name = "Company")]
        public string comp_id { get; set; }

        [RegularExpression(@"^[a-zA-Z0-9_\-]{1,20}$", ErrorMessage = "Only allows A-Z, a-z, 0-9, _ and -")]
        [StringLength(20)]
        [Required(ErrorMessage = "* Please fill up Shift ID")]
        [Display(Name = "Shift ID")]
        public string sft_Id { get; set; }

        [StringLength(50)]
        [Required(ErrorMessage = "* Please fill up Shift Name")]
        [Display(Name = "Shift Name")]
        public string name1 { get; set; }

        [StringLength(100)]
        [DataType(DataType.MultilineText)]
        [Display(Name = "Description")]
        public string description { get; set; }

        [Required(ErrorMessage = "* Required")]
        [Display(Name = "Start")]
        public TimeSpan starttime { get; set; }

        [Required(ErrorMessage = "* Required")]
        [Display(Name = "End")]
        public TimeSpan endtime { get; set; }

        [Display(Name = "Start")]
        public TimeSpan? breakstarttime { get; set; }

        [Display(Name = "End")]
        public TimeSpan? breakendtime { get; set; }

        [Display(Name = "Actual BREAK HOURS")]
        public TimeSpan? actualbreakhours { get; set; }

        [Required]
        [Display(Name = "Maximum allowable SHIFT HOURS")]
        public TimeSpan allowedshifthours { get; set; }

        [Display(Name = "Minimum HOUR/s")]
        public int? minothours { get; set; }

        [Required]
        [Display(Name = "OT Break Rules")]
        public string otrule { get; set; }

        [Display(Name = "Minute/s")]
        public int? automin1 { get; set; }

        [Display(Name = "Minute/s")]
        public int? automin2 { get; set; }

        [Display(Name = "Hours/s")]
        public int? autohours2 { get; set; }

        [Display(Name = "Minute/s")]
        public int? automin3 { get; set; }

        [Display(Name = "Hours/s")]
        public int? autohours3 { get; set; }

        [Display(Name = "From")]
        public TimeSpan? fixtimefrom { get; set; }

        [Display(Name = "To")]
        public TimeSpan? fixtimeto { get; set; }

        public bool active { get; set; }

        public DateTime? modifiedDatetime { get; set; }

        public string modifiedBy { get; set; }

        public List<ShiftRuleViewModel> shiftrules { get; set; }
    }
}