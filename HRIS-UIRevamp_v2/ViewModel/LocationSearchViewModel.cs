using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HRIS_UIRevamp_v2.ViewModel
{
    public class LocationSearchViewModel : dTableResultViewModel
    {
        public List<LocationResultViewModel> records { get; set; }
    }
}