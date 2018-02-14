using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HRIS_UIRevamp_v2.ViewModel
{
    public class RegisterViewModel
    {
        [RegularExpression(@"^[a-zA-Z0-9_\-]{1,20}$", ErrorMessage = "Only allows A-Z, a-z, 0-9, _ and -")]
        [Required(ErrorMessage = "Please enter your username.")]
        [StringLength(20)]
        [Display(Name = "Username")]
        [Remote("CheckUserIfExist", "Validation", ErrorMessage = "Duplicate Employee")]
        public string user_id { get; set; }

        [Required(ErrorMessage = "Please enter your password.")]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string c_Password { get; set; }

        [Required(ErrorMessage = "Confirm your password.")]
        [DataType(DataType.Password)]
        [Display(Name = "Confirm Password")]
        [System.ComponentModel.DataAnnotations.Compare("c_Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "Please enter your first name.")]
        [Display(Name = "First Name")]
        public string fname { get; set; }


        [Display(Name = "Middle Name")]
        public string mname { get; set; }

        [Required(ErrorMessage = "Please enter your last name.")]
        [Display(Name = "Last Name")]
        public string lname { get; set; }


        [Display(Name = "Suffix")]
        public string suffix { get; set; }

        [StringLength(100)]
        [DataType(DataType.EmailAddress, ErrorMessage = "E-mail is not valid")]
        [RegularExpression(@"([0-9]|[a-z]|[A-Z])+@(monocrete)+\.net$", ErrorMessage = "E-mail is not valid")]
        [Display(Name = "Email Address")]
        public string email1 { get; set; }

        [StringLength(100)]
        [DataType(DataType.EmailAddress, ErrorMessage = "E-mail is not valid")]
        [RegularExpression(@"([0-9]|[a-z]|[A-Z])+@(monocrete)+\.net$", ErrorMessage = "E-mail is not valid")]
        public string email2 { get; set; }
        
        [Display(Name = "Contact Numbers")]
        [RegularExpression("([0-9]{11})", ErrorMessage = "* Invalid Contact Number")]
        public string phone1 { get; set; }


        [RegularExpression("([0-9]{11})", ErrorMessage = "* Invalid Contact Number")]
        public string phone2 { get; set; }

        public bool active { get; set; }

        public string accountType { get; set; }
    }
}