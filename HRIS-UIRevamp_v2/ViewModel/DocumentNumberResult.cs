﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HRIS_UIRevamp_v2.ViewModel
{
    public class DocumentNumberResult
    {
        public string comp_id { get; set; }
        public string doc_id { get; set; }
        public string name1 { get; set; }
        public bool active { get; set; }
        public DateTime createdDateTime { get; set; }
        public long? RowNum { get; set; }
    }
}