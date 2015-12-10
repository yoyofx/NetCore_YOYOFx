using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using YOYO.Owin;
using YOYO.Owin.Helper;
using YOYO.Mvc.Reflection;
using System.Reflection;

namespace YOYO.Mvc.Route
{
    internal class MvcRouteHandler :  RouteHandler , IRouteHandler
    {
        private static ConcurrentDictionary<MethodInfo, IDynamicMethodInvoker> actionInvokerCache = new ConcurrentDictionary<MethodInfo, IDynamicMethodInvoker>();


        public MvcRouteHandler(RouteResolveResult result):base(result) {  }



        protected override void RequestHanderProcess(IOwinContext context)
        {
            var controllerType = AssemblyLoader.FindControllerTypeByName(_resolveResult.ControllerName);
            if (controllerType == null) throw new NullReferenceException("Not Found Controller Name by" + _resolveResult.ControllerName);

            var controller = (Controller)Activator.CreateInstance(controllerType);
            var actionMethodInfo = controllerType.GetMethod(_resolveResult.ActionName);

            if (actionMethodInfo == null) throw new NullReferenceException("Not Found Action Name by" + _resolveResult.ActionName);

            IDynamicMethodInvoker invoker = null;
            if (!actionInvokerCache.TryGetValue(actionMethodInfo, out invoker))
            {
                invoker = new DynamicMethodInvoker(actionMethodInfo);
                actionInvokerCache.TryAdd(actionMethodInfo, invoker);
            }
            object result = invoker.Invoke(controller,null);

            context.Response.Write(result.ToString());

        }




    }
}
