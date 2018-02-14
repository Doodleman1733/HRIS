using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HRIS_UIRevamp_v2.ViewModel
{
    public class CompanyAddViewModel
    {
        [RegularExpression(@"^[a-zA-Z0-9_\-]{1,20}$", ErrorMessage = "Only allows A-Z, a-z, 0-9, _ and -")]
        [StringLength(20)]
        [Required(ErrorMessage = "* Please fill up Company ID")]
        [Display(Name = "Company ID")]
        [Remote("CheckCompanyIfExist", "Validation", ErrorMessage = "* Duplicate Company")]
        public string comp_id { get; set; }

        [StringLength(50)]
        [Required(ErrorMessage = "* Please fill up Company Name")]
        [Display(Name = "Company Name")]
        public string name1 { get; set; }

        [StringLength(50)]
        [Display(Name = "Contact Persons")]
        public string contactperson1 { get; set; }

        [StringLength(50)]
        public string contactperson2 { get; set; }

        [Display(Name = "Mobile Number")]
        [RegularExpression(@"^(\(?\+?[0-9]*\)?)?[0-9_\- \(\)]*$", ErrorMessage = "* Invalid Phone Number")]
        public string phone1 { get; set; }

        [Display(Name = "Telephone Number")]
        [RegularExpression(@"^(\(?\+?[a-zA-Z0-9]*\)?)?[a-zA-Z0-9_\- \(\)]*$", ErrorMessage = " * Invalid Phone Number")]
        public string phone2 { get; set; }

        [StringLength(100)]
        [Display(Name = "Email 1")]
        [EmailAddress(ErrorMessage = "* Invalid Email Address")]
        public string email1 { get; set; }

        [StringLength(100)]
        [Display(Name = "Email 2")]
        [EmailAddress(ErrorMessage = "* Invalid Email Address")]
        public string email2 { get; set; }

        [StringLength(100)]
        [AllowHtml]
        [DataType(DataType.MultilineText)]
        [Display(Name = "Street Address")]
        public string streetaddress { get; set; }

        [StringLength(100)]
        [Display(Name = "City")]
        public string city { get; set; }

        [StringLength(100)]
        [Display(Name = "Province")]
        public string province { get; set; }

        [StringLength(100)]
        [Display(Name = "Country")]
        public string country { get; set; }

        [StringLength(250,ErrorMessage = "The field maximum character is 250")]
        [AllowHtml]
        [DataType(DataType.MultilineText)]
        [Display(Name = "Additional Information")]
        public string addinfo { get; set; }

        [StringLength(100)]
        [Display(Name = "SSS")]
        public string sss { get; set; }

        [StringLength(100)]
        [Display(Name = "TIN")]
        public string tin { get; set; }

        [StringLength(100)]
        [Display(Name = "PhilHealth")]
        public string philhealth { get; set; }

        [StringLength(100)]
        [Display(Name = "Pag-ibig")]
        public string pagibig { get; set; }

        [Required]
        [Display(Name = "Fiscal Year Starts by the Month of")]
        public int? fiscalyearmonth { get; set; }

        [Display(Name = "Default Shift")]
        public string defaultshift { get; set; }

        [Display(Name = "Monday")]
        public bool rdmonday { get; set; }

        [Display(Name = "Tuesday")]
        public bool rdtuesday { get; set; }

        [Display(Name = "Wednesday")]
        public bool rdwednesday { get; set; }

        [Display(Name = "Thursday")]
        public bool rdthursday { get; set; }

        [Display(Name = "Friday")]
        public bool rdfriday { get; set; }

        [Display(Name = "Saturday")]
        public bool rdsaturday { get; set; }

        [Display(Name = "Sunday")]
        public bool rdsunday { get; set; }

        [Display(Name = "Acceptable Time In Margin (in minutes)")]
        public int? timeinmargin { get; set; }

        [Display(Name = "Default Shift Round Down (in minutes)")]
        public int? shiftrounddown { get; set; }

        [Display(Name = "Default Overtime Round Down (in minutes)")]
        public int? otrounddown { get; set; }

        [Display(Name = "Maximum Allowable HOURS in a DAY")]
        public decimal? maximumworkhours { get; set; }

        [Required(ErrorMessage = "* Required")]
        [Display(Name = "Time From")]
        public TimeSpan nightdifffrom { get; set; }

        [Required(ErrorMessage = "* Required")]
        [Display(Name = "Time To")]
        public TimeSpan nightdiffto { get; set; }

        [Required(ErrorMessage = "* Required")]
        [Display(Name = "Start of time calculation for a non-regular day")]
        public string cutoffconsideration { get; set; }

        [Display(Name = "Daily")]
        public bool daily { get; set; }

        [Display(Name = "Weekly")]
        public bool weekly { get; set; }

        [Display(Name = "Weekly-Cutoff")]
        public int? weeklycutoff { get; set; }

        [Display(Name = "Semi-monthly")]
        public bool semimonthly { get; set; }

        [Display(Name = "Semi-Cutofffrom")]
        public int? semicutofffrom { get; set; }

        [Display(Name = "Semi-Cutoffto")]
        public int? semicutoffto { get; set; }

        [Display(Name = "Monthly")]
        public bool monthly { get; set; }

        [Display(Name = "Monthly-Cutoff")]
        public int? monthlycutoff { get; set; }

        public bool active { get; set; }

        public DateTime createdDatetime { get; set; }

        public string createdBy { get; set; }
    }
}