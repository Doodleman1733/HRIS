using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HRIS_UIRevamp_v2.ViewModel
{
    public class ClientKeyViewModel
    {
        public string user_id { get; set; }
        public string client_id { get; set; }
        public string client_secret { get; set; }
        public DateTime createdDateTime { get; set; }
        public bool valid { get; set; }
    }
}