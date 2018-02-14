using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HRIS_UIRevamp_v2.ViewModel
{
    public class ClientTokenViewModel
    {
        public string user_id { get; set; }
        public string client_token { get; set; }
        public DateTime createdDateTime { get; set; }
        public DateTime expiresOn { get; set; }
        public DateTime issuedOn { get; set; }
    }
}