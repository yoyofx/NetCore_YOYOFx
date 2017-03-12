using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YOYO.AspNetCore.Mvc.Reflection;
using YOYO.AspNetCore.Owin;

namespace YOYO.AspNetCore.Mvc
{
    public class ActionExecuteContext
    {
        public IOwinContext HttpContext { private set; get; }

        public string ControllerName { private set; get; }

        public string ActionName { private set; get; }

        public IDynamicMethodInvoker ActionInvoker { private set; get; }

        public IList<object> ParameterList { private set; get; }

        public object Result { set; get; }

        public ActionExecuteContext(IOwinContext context,string controllername,
            string actionname, IDynamicMethodInvoker actioninvoker, IList<object> paramterlist)
        {
            this.HttpContext = context;
            this.ControllerName = controllername;
            this.ActionName = actionname;

        }



    }
}
