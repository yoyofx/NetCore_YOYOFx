using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YOYO.Mvc.Extensions
{
    public static class StringExtensions
    {
        public static List<string> GetUrlSegments(this string roleUri)
        {
            string[] nullorqueryString = roleUri.Split('?');
            string roleStr = nullorqueryString.Length > 1 ? nullorqueryString[0] : roleUri;  //split querystring , such as "?name=1" 
            string[] segmentArray = roleStr.Split('/');

            List<string> segments = new List<string>();

            for (int i = 0; i < segmentArray.Length; i++)
                if (!String.IsNullOrEmpty(segmentArray[i]))
                    segments.Add(segmentArray[i]);

            return segments;
        }

    }
}
