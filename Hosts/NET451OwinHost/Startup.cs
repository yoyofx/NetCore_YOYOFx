using Microsoft.Owin;
using Microsoft.Owin.FileSystems;
using Microsoft.Owin.StaticFiles;
using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YOYO.Mvc.Owin;
using Microsoft.Extensions.DependencyInjection;

namespace NET451OwinHost
{
    public class Startup
    {

        public void Configuration(IAppBuilder app)
        {


            app.UseFileServer(new FileServerOptions()
            {
                EnableDefaultFiles = true,
                EnableDirectoryBrowsing = true,
                RequestPath = PathString.Empty,
                FileSystem = new PhysicalFileSystem(@"."),
            });

            app.UseWorkFolder(AppDomain.CurrentDomain.BaseDirectory);

            IServiceCollection sc = new ServiceCollection();
            sc.AddYOYOFx();

            app.UseYOYOFx(route =>
                     route.Map("/{controller}/{action}/{id}/"));


        }
    }
}
