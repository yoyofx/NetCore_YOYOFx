using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using YOYO.AspNetCore.Builder;
using YOYO.Mvc.Route;

namespace CoreHost
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<IRouteBuilder>(RouteBuilder.Builder);
            

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app , IRouteBuilder route)
        {

            ConfigureRoute(route);

            app.UseYOYOFx();

        }


        private void ConfigureRoute(IRouteBuilder route)
        {
            route.Map("/{controller}/{action}/{id}/");
        }

    }
}
