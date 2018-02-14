using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HRIS_UIRevamp_v2.ViewModel
{
    public class ModuleViewModel
    {
        public string module_id { get; set; }
        public string sdisplay { get; set; }
        public string mdisplay { get; set; }
        public string ldisplay { get; set; }
        public string description { get; set; }
        public string icon { get; set; }
        public int sequence { get; set; }
        public bool withattribute { get; set; }
        public bool withaapproval { get; set; }
        public bool withdocumentnumber { get; set; }
        public List<ModuleActionViewModel> moduleActions { get; set;}
    }
}