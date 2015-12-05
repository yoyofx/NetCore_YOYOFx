using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Owin;
using YOYO.Mvc.Route;
using YOYO.Owin;
using YOYO.Owin.Pipeline;

namespace YOYO.Mvc.Owin
{


    public static class OwinPipelineExtensions
    {
        public static IAppBuilder UseYOYOFx(this IAppBuilder app, Action<IRouteBuilder> routebuilderFunc = null, Action<Pipeline> setup = null)
        {
			routebuilderFunc ( RouteBuilder.Builder );
            var pipeline = new Pipeline();
            setup(pipeline);
            var appfunc = pipeline.Build();
            app.Use(new Func<AppFunc, AppFunc>(ignored => appfunc));
            return app;
        }

        public static void UseYOYOFx(this IAppBuilder app , Action<IRouteBuilder> routebuilder = null)
        {
            app.UseYOYOFx(  routebuilder,
                p=> p.Use(new YOYOFxOwinMiddleware() )
            );

        }

        public static void UseYOYOFx(this IAppBuilder app)
        {
            app.UseYOYOFx(null,
                p => p.Use(new YOYOFxOwinMiddleware())
            );

        }



    }
}
