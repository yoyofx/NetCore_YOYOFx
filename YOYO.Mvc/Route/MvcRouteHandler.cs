using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YOYO.Owin;
using System.Threading;

namespace YOYO.Mvc.Route
{
    internal class MvcRouteHandler : IRouteHandler
    {
        
		public  Task Process(IOwinContext context,CancellationToken cancellationToken)
        {
            var task = Task.Factory.StartNew(() => {
               


			} , cancellationToken);

            return task;

        }




    }
}
