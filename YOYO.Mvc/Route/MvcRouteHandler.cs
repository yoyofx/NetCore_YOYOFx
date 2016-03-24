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
using YOYO.Mvc.ResponseProcessor;
using YOYO.Mvc.Session;

namespace YOYO.Mvc.Route
{
    internal class MvcRouteHandler :  RouteHandler , IRouteHandler
    {

        public MvcRouteHandler(RouteResolveResult result):base(result) {  }

        protected override  void RequestHanderProcess(IOwinContext context)
        {

			IActionRuntimeProvider provider = 
				Application.CurrentApplication.Options.Bootstrapper.RuntimeManager.FindRuntimeByName (_resolveResult.ControllerName);

            var responseProcessor = ResponseProcessorFactory.GetResponseProcessor(context);
            if (responseProcessor != null && provider!=null)
            {
                ISessionProvider sessionProvider = DefaultSessionProvider.DefaultProvider;
                ISession session = sessionProvider.AccessSession(context);
                if (!context.Items.ContainsKey("session"))
                    context.Items.Add("session", session);
                else
                    context.Items["session"] = session;

                object model = provider.ExecuteAsync(_resolveResult.ControllerName, _resolveResult.ActionName, context);
                if (model != null) responseProcessor.Process(model);
                else if(model is View) context.Response.Status = Status.Is.NotFound;
            }
            else
            {
                throw new NullReferenceException(string.Format("Can't found the response processor process the request! The ContentType ={0}",context.Request.Headers.ContentType));
            }

        }




    }
}
