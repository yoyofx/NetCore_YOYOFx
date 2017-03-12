using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YOYO.AspNetCore.Mvc.Route;
using YOYO.AspNetCore.Owin;
using YOYO.AspNetCore.Owin.Pipeline;

namespace YOYO.AspNetCore.Mvc.Owin
{
    public class YOYOFxOwinMiddleware : PipelineComponent
    {

        public override async Task Invoke(IOwinContext context, AppFunc next)
        {
            IRouteBuilder builder = RouteBuilder.Builder;
            var route = builder.Resolve(context.Request);
            if (route != null)
            {
                IRouteHandler handler = RouteHandlerFactory.Default.CreateRouteHandler(context, route);

                try
                {
                    await handler.ProcessAsync(context, context.CancellationToken).ConfigureAwait(false);
                }
                catch (Exception ex)
                {
                    context.Response.Status = Status.Is.InternalServerError;
                    string message = string.Format("Error Message: {0} {1} StackTrace: {2}", 
                        ex.Message, Environment.NewLine, ex.StackTrace);

                    context.Response.Headers.ContentType = "text/html; charset=UTF-8";
                    await context.Response.WriteAsync(message);
                }
            }
            if(next!=null)
                await next(context.Environment);
        }

    }
}
