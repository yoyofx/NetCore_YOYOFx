using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YOYO.Owin.Helper
{
    internal static class UrlHelper
    {
        public static string Decode(string value)
        {
            value = value.Replace("+", " ");
            return Uri.UnescapeDataString(value);
        }

        public static string Encode(string value)
        {
            return Uri.EscapeDataString(value);
        }
    }
}
