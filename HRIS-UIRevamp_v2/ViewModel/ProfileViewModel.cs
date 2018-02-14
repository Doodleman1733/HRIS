using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HRIS_UIRevamp_v2.ViewModel
{
    public class ProfileViewModel
    {
        [RegularExpression(@"^[a-zA-Z0-9_\-]{1,20}$", ErrorMessage = "Only allows A-Z, a-z, 0-9, _ and -")]
        [StringLength(20)]
        [Required(ErrorMessage = "* Please fill up Profile ID")]
        [Display(Name = "Profile ID")]
        [Remote("CheckUserProfileIfExist", "Validation", ErrorMessage = "* Duplicate Profile")]
        public string profile_id { get; set; }

        [StringLength(50)]
        [Required(ErrorMessage = "* Please fill up Profile Name")]
        [Display(Name = "Profile Name")]
        public string name1 { get; set; }

        [StringLength(100)]
        [Display(Name = "Additional Information")]
        public string description { get; set; }
    }
}