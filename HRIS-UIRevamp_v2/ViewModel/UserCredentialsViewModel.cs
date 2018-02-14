using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HRIS_UIRevamp_v2.ViewModel
{
    public class UserCredentialsViewModel
    {
        public string user_id { get; set; }
        public string email1 { get; set; }
        public bool active { get; set; }
        public string profile_id { get; set; }
        public string c_role_id { get; set; }
        public System.DateTime createdDateTime { get; set; }
        public Nullable<long> RowNum { get; set; }
        public string username { get; set; }
    }
}