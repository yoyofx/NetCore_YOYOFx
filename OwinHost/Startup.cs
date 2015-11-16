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
    public class Startup
    {



        public void Configuration(IAppBuilder app)
        {

            app.Use<MyMiddleWareComponent>();

        }

       



    }
}
