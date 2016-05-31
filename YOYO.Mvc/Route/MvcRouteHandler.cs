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

        public override async Task ProcessAsync(IOwinContext context, CancellationToken cancellationToken)
        {
            IActionRuntimeProvider provider =
             Application.CurrentApplication.Options.Bootstrapper.RuntimeManager.FindRuntimeByName(_resolveResult.ControllerName);

            var responseProcessor = ResponseProcessorFactory.GetResponseProcessor(context);
            if (responseProcessor != null && provider != null)
            {
                ISessionProvider sessionProvider = DefaultSessionProvider.DefaultProvider;

                ISession session = await sessionProvider.AccessAsync(context);

                if (!context.Items.ContainsKey("session"))
                    context.Items.Add("session", session);
                else
                    context.Items["session"] = session;

                object actionResult = provider.ExecuteAsync(_resolveResult.ControllerName, _resolveResult.ActionName, context);
                if (actionResult != null)
                {
                    if (actionResult is Task && actionResult.GetType().GetTypeInfo().IsGenericType) //Task<TResult>
                    {
                        //get task's result
                        var taskResultProperty = actionResult.GetType().GetTypeInfo().GetProperty("Result");
                        actionResult = taskResultProperty.GetValue(actionResult);
                    }
                    responseProcessor.Process(actionResult);
                }
                //else if (actionResult is View) context.Response.Status = Status.Is.NotFound;
            }
            else
            {
                throw new NullReferenceException(string.Format("Can't found the response processor process the request! The ContentType ={0}", context.Request.Headers.ContentType));
            }
        }


        




    }
}
