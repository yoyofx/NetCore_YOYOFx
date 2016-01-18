using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YOYO.Owin;

namespace YOYO.Mvc
{
    public class ActionFilterAttribute : System.Attribute
    {
        public virtual bool OnActionExecuting(ActionExecuteContext context) { return true; }

        public virtual void OnActionExecuted(ActionExecuteContext context) { }



    }
}
