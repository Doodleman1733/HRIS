using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HRIS_UIRevamp_v2.ViewModel
{
    public class CompanyIndexViewModel : dTableSettings
    {
        [Display(Name = "Company ID")]
        public string comp_id { get; set; }
    }
}