using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YOYO.Owin.Pipeline
{
    using Env = IDictionary<string, object>;
    using AppFunc = Func< //
        IDictionary<string, object>, // owin request environment
        Task // completion signal
        >;
   
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
            await Invoke(requestEnvironment,_next);
            //await _next(requestEnvironment);
        }

        public void Setup(Env hostEnvironment)
        {
            if (_setup != null)
                _setup(hostEnvironment);
        }


        public abstract Task Invoke(Env requestEnvironment,AppFunc next);



    }
}
