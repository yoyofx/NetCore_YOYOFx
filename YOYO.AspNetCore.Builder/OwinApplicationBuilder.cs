using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using YOYO.Mvc.Route;
using YOYO.Mvc;
using YOYO.Owin.Pipeline;
using YOYO.Owin;
using YOYO.Mvc.Owin;

namespace YOYO.AspNetCore.Builder
{
    public static class OwinApplicationBuilder
    {
        private static YOYOFxOwinMiddleware Middleware = new YOYOFxOwinMiddleware();

        public static IApplicationBuilder UseYOYOFx(this IApplicationBuilder app, Action<IRouteBuilder> routebuilderFunc = null, Action<YOYOFxOptions> configuration = null)
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

            app.UseOwin(p => p(next => Invoke));
                
            return app;
        }

        public static IApplicationBuilder UseWorkFolder(this IApplicationBuilder app, string path)
        {
            HostingEnvronment.SetRootPath(path);
            return app;
        }




        public static async Task Invoke(IDictionary<string, object> environment)
        {
            var context = await OwinContext.GetContextAsync(environment);
            
            await Middleware.Invoke(context, null);
        }





    }



  
}
