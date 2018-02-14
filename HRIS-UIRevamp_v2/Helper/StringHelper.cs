using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace HRIS_UIRevamp_v2.Helper
{
    public class StringHelper
    {
        public static string urlHelper<T>(T obj) {
            var result = new List<string>();
            foreach (PropertyDescriptor property in TypeDescriptor.GetProperties(obj))
            {
                if(property.GetValue(obj) != null)
                {
                    result.Add(property.Name + "=" + HttpUtility.UrlEncode(property.GetValue(obj).ToString()));
                }
            }
            return string.Join("&", result);
        }
    }
}