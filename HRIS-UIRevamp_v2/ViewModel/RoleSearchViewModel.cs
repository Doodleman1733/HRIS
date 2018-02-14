using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HRIS_UIRevamp_v2.ViewModel
{
    public class RoleSearchViewModel : dTableResultViewModel
    {
        public List<RoleResultViewModel> records { get; set; }
    }
}