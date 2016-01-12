using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Owin;
using Microsoft.Owin.FileSystems;
using Microsoft.Owin.StaticFiles;
using Owin;
using YOYO.Mvc.Owin;

namespace YOYOFxMvcDemo
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
                FileSystem = new PhysicalFileSystem(@"F:\workspace\YOYOFx\OwinHost\bin\Debug\"),
            });

            app.UseYOYOFx(route =>
                     route.Map("/{controller}/{action}/{id}/") );



     

            //app.UseYOYOFx();

        } 


    }
}
