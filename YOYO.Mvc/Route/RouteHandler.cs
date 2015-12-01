using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YOYO.Owin;

namespace YOYO.Mvc.Route
{
    internal class RouteHandler
    {
        
       public  Task Process(IOwinContext context)
        {
            var task = Task.Factory.StartNew(() => {
                IRouteBuilder builder = RouteBuilder.Builder;
                var route = builder.Resolve(context.Request);




            } , context.CancellationToken);

            



            return task;

        }




    }
}
