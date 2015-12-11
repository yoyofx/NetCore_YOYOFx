using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Owin;
using YOYO.Mvc.Owin;

namespace YOYOFxMvcDemo
{

    public class Startup
    {

        public void Configuration(IAppBuilder app)
        {

            app.UseYOYOFx(route =>
                     route.Map("/{controller}/{action}/{id}/") );

            //app.UseYOYOFx();

        }


    }
}
