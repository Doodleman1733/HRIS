using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HRIS_UIRevamp_v2.ViewModel
{
    public class AddressIndexViewModel : dTableSettings
    {
        [Display(Name = "Address ID")]
        public string address_id { get; set; }
    }
}