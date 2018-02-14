using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HRIS_UIRevamp_v2.ViewModel
{
    public class CompanySearchViewModel : dTableResultViewModel
    {
        public List<CompanyResult> records { get; set; }
    }
}