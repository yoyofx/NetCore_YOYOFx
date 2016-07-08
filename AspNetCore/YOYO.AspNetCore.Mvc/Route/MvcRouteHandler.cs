using System;
using System.Threading;
using System.Threading.Tasks;
using YOYO.Owin;
using System.Reflection;
using YOYO.Mvc.ResponseProcessor;
using YOYO.Mvc.Session;
using YOYO.Extensions.DI;

namespace YOYO.Mvc.Route
{
    internal class MvcRouteHandler :  RouteHandler , IRouteHandler
    {
        public MvcRouteHandler(RouteResolveResult result):base(result) {  }

        public override async Task ProcessAsync(IOwinContext context, CancellationToken cancellationToken)
        {
            var serviceProvider = Application.CurrentApplication.ServiceProvider;
            var bootstrapper = serviceProvider.GetService(typeof(IYOYOBootstrapper)) as IYOYOBootstrapper;
            var runtimeProvider = bootstrapper.RuntimeManager.FindRuntimeByName(_resolveResult.ControllerName);

            if (runtimeProvider != null)
            {
                var sessionProvider = serviceProvider.GetService<ISessionProvider>();
                ISession session = await sessionProvider.AccessAsync(context);

                object actionResult = runtimeProvider.ExecuteAsync(_resolveResult.ControllerName, _resolveResult.ActionName, context);
                if (actionResult != null)
                {
                    if (actionResult is Task && actionResult.GetType().GetTypeInfo().IsGenericType) //Task<TResult>
                    {
                        //get task's result
                        var taskResultProperty = actionResult.GetType().GetTypeInfo().GetProperty("Result");
                        actionResult = taskResultProperty.GetValue(actionResult);
                    }

                    if (actionResult is IActionResult)
                        await ((IActionResult)actionResult).ProcessAsync(context);
                    else
                    {
                        var responseProcessor = ResponseProcessorFactory.GetResponseProcessor(context);
                        if (responseProcessor != null)
                            await responseProcessor.ProcessAsync(actionResult);
                        else
                            throw new NullReferenceException(string.Format("Can't found the response processor process the request! The ContentType ={0}", context.Request.Headers.ContentType));
                    }
                    

                }
            }
            else
            {
                throw new NullReferenceException("Not Action Runtime Provider!");
            }
        }


        




    }
}
