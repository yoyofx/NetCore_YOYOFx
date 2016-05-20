using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using Owin;
//using YOYO.Owin.Pipeline;

namespace OwinHost
{
    //using YOYO.Owin;
    //using YOYO.Mvc.Owin;
    //using System.IO;


    //public class Startup
    //{



    //    public void Configuration(IAppBuilder app)
    //    {

            //app.UseYOYOFx( route => 
            //            route.Map("/api/p-{controller}/{action}/{id}/") );

   //         app.UseYOYOFx(p => p.Use(async (env, next) =>
   //         {
   //             if (env[OwinConstants.Request.Path].ToString() == "/")
   //             {
   //                 var response = env["owin.ResponseBody"] as Stream;
   //                 using (var writer = new StreamWriter(response))
   //                 {
   //                     await writer.WriteAsync("<h1>Hello from My log Middleware</h1>");
   //                     await writer.WriteAsync("<h1>log Middleware first before</h1>");
   //                     await next(env);
   //                     await writer.WriteAsync("<h1>log Middleware first after</h1>");
   //                 }

   //             }
			//}).Use(new YOYOFxOwinMiddleware()));


    //    }

       



    //}
}
