using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using YOYO.Owin;
using YOYO.Owin.Helper;

namespace YOYO.Mvc.Route
{
    internal abstract class RouteHandler : IRouteHandler
    {
        protected RouteResolveResult _resolveResult = null;
        public RouteHandler(RouteResolveResult resolveResult)
        {
            _resolveResult = resolveResult;
        }


        public abstract Task ProcessAsync(IOwinContext context, CancellationToken cancellationToken);

    }
}