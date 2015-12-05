using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YOYO.Owin;
using YOYO.Owin.Helper;

namespace YOYO.Owin.Pipeline
{
    using Env = IDictionary<string, object>;
    //using AppFunc = Func< //
    //    IDictionary<string, object>, // owin request environment
    //    Task // completion signal
    //    >;
   
    using SetupAction = Action< //
       IDictionary<string, object> // owin host environment
       >;


    public abstract class PipelineComponent : IPipelineComponent
    {
        private readonly SetupAction _setup;
        private AppFunc _next;

        public void Connect(AppFunc next)
        {
            _next = next;
        }

        public  Task Execute(Env requestEnvironment)
        {
            IOwinContext context = new OwinContext(requestEnvironment);
            var tcs = new TaskCompletionSource<bool>();
			var pipelineInvoker = Invoke( context , _next) ;

			pipelineInvoker.WhenCompleted ( onComplele => tcs.SetResult (true),  OnFaulted => {
				tcs.SetException(OnFaulted.Exception);
				context.Response.WriteAsync(OnFaulted.Exception.ToString() + OnFaulted.Exception.StackTrace).Wait();
			});
			return tcs.Task;
        }

        public void Setup(Env hostEnvironment)
        {
            if (_setup != null)
                _setup(hostEnvironment);
        }


        public abstract Task Invoke(IOwinContext context ,AppFunc next);



    }
}
