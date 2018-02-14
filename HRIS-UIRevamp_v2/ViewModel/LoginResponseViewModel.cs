using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HRIS_UIRevamp_v2.ViewModel
{
    public class LoginResponseViewModel
    {
        public string user_id { get; set; }
        public string fname { get; set; }
        public string mname { get; set; }
        public string lname { get; set; }
        public string suffix { get; set; }
        public string email1 { get; set; }
        public string email2 { get; set; }
        public string phone1 { get; set; }
        public string phone2 { get; set; }
        public string accountType { get; set; }
        public int loginAttempts { get; set; }
        public bool active { get; set; }
        public bool locked { get; set; }
    }
}