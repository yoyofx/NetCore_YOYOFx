using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using YOYO.Mvc.Route;
using YOYO.Mvc;
using YOYO.Owin;
using YOYO.Mvc.Owin;
using Microsoft.Extensions.DependencyInjection;
using YOYO.Mvc.ActionRuntime;

#if NET451
using AppBuilder = Owin.IAppBuilder;
#else
using AppBuilder = Microsoft.AspNetCore.Builder.IApplicationBuilder;
#endif

namespace YOYO.AspNetCore.Builder
{
    public static class OwinApplicationBuilder
    {
        private static YOYOFxOwinMiddleware Middleware = new YOYOFxOwinMiddleware();

        private static AppBuilder UseYOYOFx(this AppBuilder app, Action<IRouteBuilder> routebuilderFunc = null, Action<YOYOFxOptions> configuration = null)
        {
            YOYOFxOptions options = new YOYOFxOptions();
            if (configuration != null)
                configuration(options);

            options.Bootstrapper.Initialise();

            Application.CurrentApplication.SetOptions(options);

            IRouteBuilder routeBuilder = RouteBuilder.Builder;

            //default route role
            routeBuilder.Map("/{controller}/{action}/{id}/");

            if (routebuilderFunc!=null)
                routebuilderFunc(RouteBuilder.Builder);


            if (Application.CurrentApplication.ServiceProvider == null)
            {
                IServiceCollection sc = new ServiceCollection();
                sc.AddYOYOFx();
            }


            return app;
        }


#if NET451
         public static AppBuilder UseYOYOFxOwin(this AppBuilder app, Action<IRouteBuilder> routebuilderFunc = null, Action<YOYOFxOptions> configuration = null)
        {
            UseYOYOFx(app, routebuilderFunc, configuration);
            app.Use(new Func<AppFunc,AppFunc>(next => Invoke));
            return app;
        }
#else
        public static AppBuilder UseYOYOFxCore(this AppBuilder app, Action<IRouteBuilder> routebuilderFunc = null, Action<YOYOFxOptions> configuration = null)
        {
            UseYOYOFx(app, routebuilderFunc, configuration);
            app.UseOwin(p => p(next => Invoke));
            return app;
        }
#endif


        public static AppBuilder UseWorkFolder(this AppBuilder app, string path)
        {
            HostingEnvronment.SetRootPath(path);
            return app;
        }

        
        public static async Task Invoke(IDictionary<string, object> environment)
        {
            var context = await OwinContext.GetContextAsync(environment);
            
            await Middleware.Invoke(context, null);
        }


        public static void AddYOYOFx(this IServiceCollection services)
        {
            services.AddSingleton<IControllerFacotry,DefaultControllerFactory>();
            services.AddSingleton<IRouteBuilder>(RouteBuilder.Builder);
            Application.CurrentApplication.ServiceProvider = services.BuildServiceProvider();
        }


    }



  
}
