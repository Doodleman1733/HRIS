using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HRIS_UIRevamp_v2.ViewModel
{
    public class LocationUpdateViewModel
    {
        [Required(ErrorMessage = "* Please select Company")]
        [Display(Name = "Company ID")]
        public string comp_id { get; set; }

        [RegularExpression(@"^[a-zA-Z0-9_\-]{1,20}$", ErrorMessage = "Only allows A-Z, a-z, 0-9, _ and -")]
        [Required (ErrorMessage = "* Please fill up Location ID")]
        [Display(Name = "Location ID")]
        public string loc_id { get; set; }

        [Required(ErrorMessage = "* Please fill up Location Name")]
        [Display(Name = "Location Name")]
        public string name1 { get; set; }
        
        public string description { get; set; }

        public string contactperson1 { get; set; }

        public string contactperson2 { get; set; }

        [Display(Name = "Mobile Number")]
        [RegularExpression(@"^(\(?\+?[0-9]*\)?)?[0-9_\- \(\)]*$", ErrorMessage = "* Invalid Phone Number")]
        public string phone1 { get; set; }

        [Display(Name = "Telephone Number")]
        [RegularExpression(@"^(\(?\+?[a-zA-Z0-9]*\)?)?[a-zA-Z0-9_\- \(\)]*$", ErrorMessage = " * Invalid Phone Number")]
        public string phone2 { get; set; }

        [Display(Name = "Email 1")]
        [EmailAddress(ErrorMessage = "* Invalid Email Address")]
        public string email1 { get; set; }

        [Display(Name = "Email 2")]
        [EmailAddress(ErrorMessage = "* Invalid Email Address")]
        public string email2 { get; set; }

        [Display(Name = "Street")]
        public string streetaddress { get; set; }

        [Display(Name = "City")]
        public string city { get; set; }

        [Display(Name = "Province")]
        public string province { get; set; }

        [Display(Name = "Country")]
        public string country { get; set; }

        [AllowHtml]
        [DataType(DataType.MultilineText)]
        [Display(Name = "Additional Information")]
        [StringLength(250, ErrorMessage = "The field maximum character is 250")]
        public string addinfo { get; set; }
        
        public bool active { get; set; }
        
        public DateTime? modifiedDatetime { get; set; }
        
        public string modifiedBy { get; set; }
        
    }
}