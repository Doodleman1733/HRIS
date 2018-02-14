using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HRIS_UIRevamp_v2.ViewModel
{
    public class WorkflowSearchViewModel : dTableResultViewModel
    {
        public List<WorkflowViewModel> records { get; set; }
    }
}