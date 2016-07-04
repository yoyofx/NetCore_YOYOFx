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
    using ActionRuntime;


#if NET451
    using global::Owin;
    using Microsoft.Extensions.DependencyInjection;

    public static class OwinPipelineExtensions
    {
        public static IAppBuilder UseYOYOFx(this IAppBuilder app, Action<IRouteBuilder> routebuilderFunc = null, Action<Pipeline> setup = null, Action<YOYOFxOptions> configuration = null)
        {
            YOYOFxOptions options = new YOYOFxOptions();
            if (configuration != null)
                configuration(options);

            options.Bootstrapper.Initialise();



            Application.CurrentApplication.SetOptions(options);

			routebuilderFunc ( RouteBuilder.Builder );
            var pipeline = new Pipeline();
            setup(pipeline);
            var appfunc = pipeline.Build();
            app.Use(new Func<AppFunc, AppFunc>(ignored => appfunc));
            return app;
        }

        public static IAppBuilder UseWorkFolder(this IAppBuilder app ,string path)
        {
            HostingEnvronment.SetRootPath(path);
            return app;
        }


        public static void UseYOYOFx(this IAppBuilder app, Action<IRouteBuilder> routebuilder = null, Action<YOYOFxOptions> configuration = null)
        {
            app.UseYOYOFx(routebuilder,
                p => p.Use(new YOYOFxOwinMiddleware()) , configuration
            );

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

        public static void AddYOYOFx(this IServiceCollection services)
        {
            services.AddSingleton<IControllerFacotry, DefaultControllerFactory>();
            services.AddSingleton<IRouteBuilder>(RouteBuilder.Builder);
            Application.CurrentApplication.ServiceProvider = services.BuildServiceProvider();
        }

    }
#endif


}
