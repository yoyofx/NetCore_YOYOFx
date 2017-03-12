using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YOYO.AspNetCore.Mvc.Filters
{
    public class NoCacheAttribute: ActionFilterAttribute
    {
        public override bool OnActionExecuting(ActionExecuteContext context)
        {
            context.HttpContext.Response.Headers.CacheControl = "no-cache, no-store, max-age=0";
            context.HttpContext.Response.Headers.Pragma = "no-cache";
            context.HttpContext.Response.Headers.Expires = "-1";


            return base.OnActionExecuting(context);
        }

    }
}
