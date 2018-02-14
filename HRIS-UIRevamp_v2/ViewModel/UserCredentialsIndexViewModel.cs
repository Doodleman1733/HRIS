using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HRIS_UIRevamp_v2.ViewModel
{
    public class UserCredentialsIndexViewModel : dTableSettings
    {
        [Display(Name = "User ID")]
        public string user_id { get; set; }

        [Display(Name = "Employee Name")]
        public string username { get; set; }
    }
}