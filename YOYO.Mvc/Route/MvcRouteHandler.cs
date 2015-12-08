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
    internal class MvcRouteHandler : IRouteHandler
    {
        private RouteResolveResult _resolveResult = null;

        public MvcRouteHandler(){ }


        public MvcRouteHandler(RouteResolveResult result) { _resolveResult = result; }

        public Task Process(IOwinContext context,CancellationToken cancellationToken)
        {
            var tcs = new TaskCompletionSource<bool>();
            Task handlerTask = Task.Factory.StartNew(asyncProcessHander, context , cancellationToken );


            handlerTask.WhenCompleted( complete => {
                tcs.SetResult(true);
            },  faulted => {
                context.Response.Write(faulted.Exception.ToString() + faulted.Exception.StackTrace.ToString());
                tcs.SetException(faulted.Exception);
            });


            return tcs.Task;
        }

        public void SetRouteResult(RouteResolveResult result)
        {
            _resolveResult = result;
        }



        private void asyncProcessHander(object contextobj)
        {
            var Context = contextobj as IOwinContext;
            var controllerType = AssemblyLoader.FindControllerTypeByName(_resolveResult.ControllerName);
            if (controllerType == null) throw new NullReferenceException("Not Found Controller Name by" + _resolveResult.ControllerName);
       
            var controller = (Controller)Activator.CreateInstance(controllerType);
            var actionMethodInfo = controllerType.GetMethod(_resolveResult.ActionName);

            if(actionMethodInfo== null) throw new NullReferenceException("Not Found Action Name by" + _resolveResult.ActionName);


            object result = actionMethodInfo.Invoke(controller, null);

            Context.Response.Write(result.ToString());



        }




    }
}
