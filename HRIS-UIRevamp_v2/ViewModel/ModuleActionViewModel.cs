using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HRIS_UIRevamp_v2.ViewModel
{
    public class ModuleActionViewModel
    {
        public string module_id { get; set; }
        public string action_id { get; set; }
        public string sdisplay { get; set; }
        public string mdisplay { get; set; }
        public string ldisplay { get; set; }
        public string description { get; set; }
        public string icon { get; set; }
        public int sequence { get; set; }
    }
}