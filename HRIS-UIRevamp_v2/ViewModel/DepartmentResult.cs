using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HRIS_UIRevamp_v2.ViewModel
{
    public class DepartmentResult
    {
        public string comp_id { get; set; }
        public string div_id { get; set; }
        public string dept_id { get; set; }
        public string name1 { get; set; }
        public bool active { get; set; }
        public DateTime createdDateTime { get; set; }
        public Nullable<long> RowNum { get; set; }
    }
}