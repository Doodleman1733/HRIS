using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HRIS_UIRevamp_v2.ViewModel
{
    public class UserRoleAddViewModel
    {

        [RegularExpression(@"^[a-zA-Z0-9_\-]{1,20}$", ErrorMessage = "Only allows A-Z, a-z, 0-9, _ and -")]
        [StringLength(20)]
        [Required(ErrorMessage = "* Please fill up Role ID")]
        [Display(Name = "Role ID")]
        [Remote("CheckUserRoleIfExist", "Validation", ErrorMessage = "* Duplicate Role")]
        public string c_role_id { get; set; }

        [StringLength(50)]
        [Required(ErrorMessage = "* Please fill up Role Name")]
        [Display(Name = "Role Name")]
        public string name1 { get; set; }

        [StringLength(100)]
        [Display(Name = "Additional Information")]
        public string description { get; set; }

        public bool active { get; set; }

        public ProfileViewModel profile { get; set;}

        public DateTime createdDatetime { get; set; }

        public string createdBy { get; set; }

        public List<string> module_ids { get; set; }
        public List<ModuleViewModel> modules { get; set; }
        public List<ModuleActionIDViewModel> moduleActions_ids { get; set; }

    }
}