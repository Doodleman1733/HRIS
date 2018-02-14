using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HRIS_UIRevamp_v2.ViewModel
{
    public class UserCredentialsUpdateViewModel
    {
        [Display(Name = "User ID")]
        [StringLength(20)]
        public string user_id { get; set; }
        
        [Display(Name = "Password")]
        public string c_password { get; set; }
        
        [Display(Name = "Confirm Password")]
        public string con_password { get; set; }

        public string fname { get; set; }

        public string mname { get; set; }

        [Required(ErrorMessage = "* Required")]
        public string lname { get; set; }

        public string suffix { get; set; }

        [StringLength(100)]
        [EmailAddress(ErrorMessage = "* Invalid Email Address")]
        public string email1 { get; set; }

        [StringLength(100)]
        [EmailAddress(ErrorMessage = "* Invalid Email Address")]
        public string email2 { get; set; }

        [RegularExpression("([0-9]{11})", ErrorMessage = "* Invalid Contact Number")]
        public string phone1 { get; set; }

        [RegularExpression("([0-9]{11})", ErrorMessage = "* Invalid Contact Number")]
        public string phone2 { get; set; }

        public bool active { get; set; }
        
        [Required(ErrorMessage = "* Please select Profile")]
        [Display(Name = "Profiles")]
        public string profile_id { get; set; }

        [Required(ErrorMessage = "* Please select Role")]
        [Display(Name = "Role")]
        public string c_role_id { get; set; }

        public DateTime modifiedDateTime { get; set; }

        public string modifiedBy { get; set; }
    }
}