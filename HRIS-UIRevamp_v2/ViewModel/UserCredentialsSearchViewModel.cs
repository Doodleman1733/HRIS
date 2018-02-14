using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HRIS_UIRevamp_v2.ViewModel
{
    public class UserCredentialsSearchViewModel : dTableResultViewModel
    {
        public List<UserCredentialsViewModel> records { get; set; }
    }
}