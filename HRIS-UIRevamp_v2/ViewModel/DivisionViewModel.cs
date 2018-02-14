using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HRIS_UIRevamp_v2.ViewModel
{
    public class DivisionViewModel
    {
        [Display(Name = "Company")]
        public string comp_id { get; set; }

        [Display(Name = "Division ID")]
        public string div_id { get; set; }

        [Display(Name = "Division Name")]
        public string name1 { get; set; }

        [Display(Name = "Additional Information")]
        public string description { get; set; }

        public List<DepartmentAddViewModel> departments { get; set; }

        public List<SectionAddViewModel> sections { get; set; }

        [RegularExpression(@"^[a-zA-Z0-9_\-]{1,20}$", ErrorMessage = "* Only allows A-Z, a-z, 0-9, _ and -")]
        public string dept_id { get; set; }

        public string dept_name1 { get; set; }

        public string dept_description { get; set; }

        [RegularExpression(@"^[a-zA-Z0-9_\-]{1,20}$", ErrorMessage = "* Only allows A-Z, a-z, 0-9, _ and -")]
        public string sect_id { get; set; }

        public string sect_name1 { get; set; }

        public string sect_description { get; set; }
    }
}