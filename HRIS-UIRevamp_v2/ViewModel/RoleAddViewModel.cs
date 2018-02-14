using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HRIS_UIRevamp_v2.ViewModel
{
    public class RoleAddViewModel
    {
        [Required(ErrorMessage = "* Please select Company")]
        [Display(Name = "Company")]
        public string comp_id { get; set; }

        [RegularExpression(@"^[a-zA-Z0-9_\-]{1,20}$", ErrorMessage = "Only allows A-Z, a-z, 0-9, _ and -")]
        [Required(ErrorMessage ="* Please fill up Role ID")]
        [Display(Name = "Role ID")]
        [Remote("CheckRoleIfExist", "Validation", AdditionalFields = "comp_id", ErrorMessage = "Duplicate Role")]
        public string role_id { get; set; }

        [Required(ErrorMessage ="* Please fill up Role Name")]
        [Display(Name = "Role Name")]
        public string name1 { get; set; }

        [Display(Name = "Description")]
        public string description { get; set; }

        public bool active { get; set; }

        public DateTime createdDatetime { get; set; }

        public string createdBy { get; set; }
    }
}