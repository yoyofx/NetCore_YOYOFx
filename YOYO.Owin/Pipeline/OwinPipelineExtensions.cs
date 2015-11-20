using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Owin;

namespace YOYO.Owin.Pipeline
{

    using AppFunc = Func< //
               IDictionary<string, object>, // owin request environment
               Task // completion signal
               >;
    public static class OwinPipelineExtensions
    {
        public static void UsePipeline(this IAppBuilder app,Action<Pipeline> setup)
        {
            var pipeline = new Pipeline();
            setup(pipeline);
            var appfunc = pipeline.Build();
            app.Use(new Func<AppFunc, AppFunc>(ignored => appfunc));
        }



    }
}
