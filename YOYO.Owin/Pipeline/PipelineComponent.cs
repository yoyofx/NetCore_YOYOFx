using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YOYO.Owin;

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

        public async Task Execute(Env requestEnvironment)
        {
            await Invoke(new OwinContext(requestEnvironment),_next);
        }

        public void Setup(Env hostEnvironment)
        {
            if (_setup != null)
                _setup(hostEnvironment);
        }


        public abstract Task Invoke(IOwinContext context ,AppFunc next);



    }
}
