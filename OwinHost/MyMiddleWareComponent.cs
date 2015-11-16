using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OwinHost
{
    using Env = IDictionary<string, object>;
    using AppFunc = Func< //
        IDictionary<string, object>, // owin request environment
        Task // completion signal
        >;
    using MiddlewareFunc = Func< //
        IDictionary<string, object>, // owin request environment
        Func<IDictionary<string, object>, Task>, // next AppFunc in pipeline
        Task // completion signal
        >;
    using System.IO;

    public class MyMiddleWareComponent
    {
        AppFunc _next;
        public MyMiddleWareComponent(AppFunc next)
        {
            _next = next;
        }

        public async Task Invoke(Env environment)
        {
            var response = environment["owin.ResponseBody"] as Stream;
            using (var writer = new StreamWriter(response))
            {
                await writer.WriteAsync("<h1>Hello from My First Middleware</h1>");
            }
            await _next(environment);
        }

    }
}
