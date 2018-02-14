using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HRIS_UIRevamp_v2.ViewModel
{
    public class AddressUpdateViewModel
    {
        [Display(Name = "Address ID")]
        public long address_id { get; set; }

        [Display(Name = "Name 1")]
        public string name1 { get; set; }

        [Display(Name = "Name 2")]
        public string name2 { get; set; }

        [Display(Name = "Name 3")]
        public string name3 { get; set; }

        [Display(Name = "Description")]
        public string description { get; set; }

        [Display(Name = "Street Address")]
        public string streetaddress { get; set; }

        [Display(Name = "City")]
        public string city { get; set; }

        [Display(Name = "Province")]
        public string province { get; set; }

        [Display(Name = "Country")]
        public string country { get; set; }

        [Display(Name = "Additional Information")]
        public string addinfo { get; set; }

        [Display(Name = "Postal Code")]
        public string postalcode { get; set; }

        [Display(Name = "Contact Person 1")]
        public string contactperson1 { get; set; }

        [Display(Name = "Contact Person 2")]
        public string contactperson2 { get; set; }

        [Display(Name = "Phone 1")]
        public string phone1 { get; set; }

        [Display(Name = "Phone 2")]
        public string phone2 { get; set; }

        [Display(Name = "Email 1")]
        public string email1 { get; set; }

        [Display(Name = "Email 2")]
        public string email2 { get; set; }

        public bool active { get; set; }
        public DateTime modifiedDateTime { get; set; }
        public string modifiedBy { get; set; }
    }
}