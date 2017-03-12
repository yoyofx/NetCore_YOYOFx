using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YOYO.AspNetCore.Owin.Pipeline
{
    using Env = IDictionary<string, object>;
 

    using SetupAction = Action< //
       IDictionary<string, object> // owin host environment
       >;


    internal class MiddleWareDelegateComponent : IPipelineComponent
    {
        private readonly MiddlewareFunc _middleware;
        private readonly SetupAction _setup;
        private AppFunc _next;

        public MiddleWareDelegateComponent(MiddlewareFunc middleware, SetupAction setup = null)
        {
            _middleware = middleware;
            _setup = setup;
        }

        public void Connect(AppFunc next)
        {
            _next = next;
        }

        public Task Execute(Env requestEnvironment)
        {
            return _middleware(requestEnvironment,_next);
        }

        public void Setup(Env hostEnvironment)
        {
            if (_setup != null)
                _setup(hostEnvironment);
        }
    }
}
