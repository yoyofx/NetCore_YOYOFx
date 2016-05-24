using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Owin;
using YOYO.Mvc.Owin;
using Microsoft.Owin.StaticFiles;
using Microsoft.Owin;
using Microsoft.Owin.FileSystems;

namespace YOYO.Owin.Demo
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

            app.UseYOYOFx(route =>
                     route.Map("/{controller}/{action}/{id}/"));





            //app.UseYOYOFx();

        }
    }
}
