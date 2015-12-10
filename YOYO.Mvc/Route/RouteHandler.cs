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


        public Task Process(IOwinContext context, CancellationToken cancellationToken)
        {
            var tcs = new TaskCompletionSource<bool>();
            Task handlerTask = Task.Factory.StartNew(asyncProcessHander, context, cancellationToken);


            handlerTask.WhenCompleted(complete => {
                tcs.SetResult(true);
            }, faulted => {
                context.Response.Write(faulted.Exception.ToString() + faulted.Exception.StackTrace.ToString());
                tcs.SetException(faulted.Exception);
            });


            return tcs.Task;
        }

        private void asyncProcessHander(object contextobj)
        {
            var context = contextobj as IOwinContext;
            RequestHanderProcess(context);
        }

        protected abstract void RequestHanderProcess(IOwinContext context);

    }
}
