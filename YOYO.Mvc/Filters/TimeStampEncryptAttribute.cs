using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YOYO.Mvc.Filters
{
    public class TimeStampEncryptAttribute : YOYO.Mvc.ActionFilterAttribute
    {
        public override bool OnActionExecuting(ActionExecuteContext context)
        {
            string timestampString = context.HttpContext.Request["timestamp"];
            if (!string.IsNullOrEmpty(timestampString))
            {
                double timestamp;
                if (!double.TryParse(timestampString, out timestamp))
                    return false;


                var requestDateTime = new DateTime(1970, 01, 01).AddMilliseconds(timestamp);

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


    }


}
