using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OwinHost
{

    using System.IO;
    using YOYO.Owin;
    using YOYO.Owin.Pipeline;

    public class MyMiddleWareComponent : PipelineComponent
    {

        public override async Task Invoke(IOwinContext context, AppFunc next)
        {
            if (context.Request.Path == "/")
            {
               await context.Response.WriteAsync("<h1>Hello from My First Middleware</h1>");
            }
            await next(context.Environment);
        }



    }
}
