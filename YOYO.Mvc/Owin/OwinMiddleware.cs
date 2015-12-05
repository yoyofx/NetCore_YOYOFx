using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YOYO.Mvc.Route;
using YOYO.Owin;
using YOYO.Owin.Pipeline;

namespace YOYO.Mvc.Owin
{
    public class YOYOFxOwinMiddleware : PipelineComponent
    {

        public override async Task Invoke(IOwinContext context, AppFunc next)
        {
			IRouteBuilder builder = RouteBuilder.Builder;
			var route = builder.Resolve(context.Request);
			IRouteHandler handler = RouteHandlerFactory.Default.CreateRouteHandler (route);

			await handler.Process(context,context.CancellationToken);

            //if (context.Request.Path == "/")
            //{
            //    await context.Response.WriteAsync("<h1>Hello from My First Middleware</h1>");
            //}
            await next(context.Environment);

        }

    }
}
