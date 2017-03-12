using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YOYO.AspNetCore.Mvc.Filters
{
    public class TimeStampEncryptAttribute : YOYO.AspNetCore.Mvc.ActionFilterAttribute
    {
        public override bool OnActionExecuting(ActionExecuteContext context)
        {
            string timestampString = context.HttpContext.Request["timestamp"];
            if (!string.IsNullOrEmpty(timestampString))
            {
                double timestamp;
                if (!double.TryParse(timestampString, out timestamp))
                    return false;


                var requestDateTime = UnixTimeStampToDateTime(timestamp);

                var time = DateTime.Now.Subtract(requestDateTime);

                if (time.TotalMinutes > 0 && time.TotalMinutes < 2)
                    return true;
                else
                    return false;
            }
            else
            {
                return false;
            }
        }


        private static DateTime UnixTimeStampToDateTime(double unixTimeStamp)
        {
            // Unix timestamp is seconds past epoch
            System.DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
            dtDateTime = dtDateTime.AddMilliseconds(unixTimeStamp).ToLocalTime();
            return dtDateTime;
        }


    }


}
