using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HRIS_UIRevamp_v2.ViewModel
{
    public class EmployeeClassResultViewModel
    {
        public string comp_id { get; set; }
        public string class_id { get; set; }
        public string name1 { get; set; }
        public bool active { get; set; }
        public long? RowNum { get; set; }
    }
}