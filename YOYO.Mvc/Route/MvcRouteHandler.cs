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
using YOYO.Mvc.ActionRuntime;

namespace YOYO.Mvc.Route
{
    internal class MvcRouteHandler :  RouteHandler , IRouteHandler
    {

        public MvcRouteHandler(RouteResolveResult result):base(result) {  }

        protected override  void RequestHanderProcess(IOwinContext context)
        {

			IActionRuntimeProvider provider = 
				Application.CurrentApplication.Options.Bootstrapper.RuntimeManager.FindRuntimeByName (_resolveResult.ControllerName);

			object result =  provider.ExecuteAsync(_resolveResult.ControllerName, _resolveResult.ActionName, context);

            context.Response.Write(result.ToString());


        }




    }
}
