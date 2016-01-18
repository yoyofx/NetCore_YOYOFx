using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using YOYO.Mvc;

namespace YOYOFxMvcDemo
{
    public class EncryptAttribute : YOYO.Mvc.ActionFilterAttribute
    {
        public override bool OnActionExecuting(ActionExecuteContext context)
        {
            string timestamp = context.HttpContext.Request["timestamp"];
            if(!string.IsNullOrEmpty(timestamp))
            {
                return true;
            }
            else
            {
                return false;
            }
        }


    }
}