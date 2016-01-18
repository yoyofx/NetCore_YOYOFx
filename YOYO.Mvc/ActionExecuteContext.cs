using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YOYO.Mvc.Reflection;
using YOYO.Owin;

namespace YOYO.Mvc
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
