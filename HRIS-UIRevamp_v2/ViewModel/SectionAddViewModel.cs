using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HRIS_UIRevamp_v2.ViewModel
{
    public class SectionAddViewModel
    {

        [StringLength(20)]
        [Required]
        [Display(Name = "Company")]
        public string comp_id { get; set; }

        [StringLength(20)]
        [Required]
        [Display(Name = "Division")]
        public string div_id { get; set; }


        [StringLength(20)]
        [Required]
        [Display(Name = "Department")]
        public string dept_id { get; set; }


        [RegularExpression(@"^[a-zA-Z0-9_\-]{1,20}$", ErrorMessage = "Only allows A-Z, a-z, 0-9, _ and -")]
        [StringLength(20)]
        [Required]
        [Display(Name = "Section ID")]
        //[Remote("CheckSectionIfExist", "Validation", AdditionalFields = "sec_Company_Id,sec_Division_Id,sec_Department_Id", ErrorMessage = "Duplicate Section")]
        public string sect_id { get; set; }

        [StringLength(50)]
        [Required]
        [Display(Name = "Section Name")]
        public string name1 { get; set; }

        [StringLength(100)]
      
        [DataType(DataType.MultilineText)]
        [Display(Name = "Description")]
        public string description { get; set; }

        public bool active { get; set; }

        public DateTime createdDatetime { get; set; }

        public string createdBy { get; set; }
    }
}