using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HRIS_UIRevamp_v2.ViewModel
{
    public class DocumentNumberAddViewModel
    {
        [StringLength(20)]
        [Required(ErrorMessage = "* Please Select Company")]
        [Display(Name = "Company")]
        public string comp_id { get; set; }

        [RegularExpression(@"^[a-zA-Z0-9_\-]{1,20}$", ErrorMessage = "Only allows A-Z, a-z, 0-9, _ and -")]
        [StringLength(5)]
        [Required(ErrorMessage = "* Please fill up Document ID")]
        [Display(Name = "Document ID")]
        [Remote("CheckDocumentNumberIfExist", "Validation", AdditionalFields = "comp_id", ErrorMessage = "*Duplicate Document ID")]
        public string doc_id { get; set; }

        [StringLength(50)]
        [Required(ErrorMessage = "*Please fill up Document Name")]
        [Display(Name = "Document Name")]
        public string name1 { get; set; }

        [Display(Name = "Range From")]
        [Required]
        public decimal rangefrom { get; set; }

        [Display(Name = "Range To")]
        [Required]
        public decimal rangeto { get; set; }

        [Display(Name = "Increment")]
        [Required]
        public decimal increment { get; set; }

        [Display(Name = "Starting Value")]
        [Required]
        public decimal startvalue { get; set; }

        [Required]
        [Display(Name = "Current Value")]
        public decimal currentvalue { get; set; }

        public bool active { get; set; }

        public DateTime createdDateTime { get; set; }

        public string createdBy { get; set; }
        
        [Required(ErrorMessage = "* Please Select Module")]
        [Display(Name = "Module")]
        public List<ModuleViewModel> module { get; set; }
    }
}