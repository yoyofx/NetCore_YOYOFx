using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Owin;
using YOYO.Owin.Pipeline;

namespace OwinHost
{
    using Env = IDictionary<string, object>;
    using AppFun = Func<IDictionary<String, object>, Task>;
    using MiddlewareFunc = Func< //
       IDictionary<string, object>, // owin request environment
       Func<IDictionary<string, object>, Task>, // next AppFunc in pipeline
       Task // completion signal
       >;
    using YOYO.Owin;
    using System.IO;

    public class Startup
    {



        public void Configuration(IAppBuilder app)
        {

            app.UsePipeline(p => p.Use(async (env, next) =>
            {
                if (env[OwinConstants.Request.Path].ToString() == "/")
                {
                   
                    var response = env["owin.ResponseBody"] as Stream;
                    using (var writer = new StreamWriter(response))
                    {
                        await writer.WriteAsync("<h1>Hello from My log Middleware</h1>");
                        await writer.WriteAsync("<h1>log Middleware first before</h1>");
                        await next(env);
                        await writer.WriteAsync("<h1>log Middleware first after</h1>");
                    }


                    
                }

				}).Use(FormsMiddleware.ParseFormData));


        }

       



    }
}
