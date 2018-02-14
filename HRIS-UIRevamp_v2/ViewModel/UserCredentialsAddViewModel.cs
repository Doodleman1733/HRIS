using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HRIS_UIRevamp_v2.ViewModel
{
    public class UserCredentialsAddViewModel
    {
        [RegularExpression(@"^[a-zA-Z0-9_\-]{1,20}$", ErrorMessage = "* Only allows A-Z, a-z, 0-9, _ and -")]
        [Required(ErrorMessage = "* Please fill up User ID.")]
        [Display(Name = "User ID")]
        [StringLength(20)]
        [Remote("CheckUserIfExist", "Validation", ErrorMessage = "Duplicate Employee")]
        public string user_id { get; set; }

        [Required(ErrorMessage = "* Please enter Password.")]
        [StringLength(100, ErrorMessage = "* The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string c_password { get; set; }

        [Required(ErrorMessage = "* Please verify Password.")]
        [DataType(DataType.Password)]
        [System.ComponentModel.DataAnnotations.Compare("c_password", ErrorMessage = "* The password and confirmation password do not match.")]
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

        [RegularExpression("([0-9]{11})", ErrorMessage = "* Contact number is not valid")]
        public string phone1 { get; set; }

        [RegularExpression("([0-9]{11})", ErrorMessage = "* Contact number is not valid")]
        public string phone2 { get; set; }
        
        public bool active { get; set; }
        
        public DateTime createdDateTime { get; set; }

        public string createdBy { get; set; }

        [Required(ErrorMessage = "* Please select Profile")]
        [Display(Name = "Profiles")]
        public string profile_id { get; set; }

        [Required(ErrorMessage = "* Please select Role")]
        [Display(Name = "Role")]
        public string c_role_id { get; set; }
    }
}