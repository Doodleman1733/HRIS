using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HRIS_UIRevamp_v2.ViewModel
{
    public class dTableSettings
    {
        public Dictionary<string, string> queries { get; set; }
        public Dictionary<string, int> sorts { get; set; }
        public int page { get; set; }
        public int perPage { get; set; }
        public int offset { get; set; }
    }
}