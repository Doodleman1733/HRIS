﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HRIS_UIRevamp_v2.ViewModel
{
    public class RoleIndexViewModel : dTableSettings
    {
        [Display(Name = "Company")]
        public string comp_id { get; set; }

        [Display(Name = "Role ID")]
        public string role_id { get; set; }
    }
}