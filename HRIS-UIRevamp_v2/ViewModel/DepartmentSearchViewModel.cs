using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HRIS_UIRevamp_v2.ViewModel
{
    public class DepartmentSearchViewModel : dTableResultViewModel
    {
        public List<DepartmentResult> records { get; set; }
    }
}