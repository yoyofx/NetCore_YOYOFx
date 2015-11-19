using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Owin;

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
                    await next(env);
                    var response = env["owin.ResponseBody"] as Stream;
                    using (var writer = new StreamWriter(response))
                    {
                        await writer.WriteAsync("<h1>Hello from My second Middleware</h1>");
                    }
                    
                }

            }).Use(new MyMiddleWareComponent()));




        }

       



    }
}
