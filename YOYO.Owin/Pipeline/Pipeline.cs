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
    using MiddlewareFunc = Func< //
        IDictionary<string, object>, // owin request environment
        Func<IDictionary<string, object>, Task>, // next AppFunc in pipeline
        Task // completion signal
        >;
    using SetupAction = Action< //
        IDictionary<string, object> // owin host environment
        >;
    

    public class Pipeline : IPipeline
    {
        private readonly List<IPipelineComponent> _components = new List<IPipelineComponent>();


        public static AppFunc ReturnDone
        {
            get { return environment => OwinConstants.TaskHelper.Completed(); }
        }

        public AppFunc Build()
        {
            if (_components.Count == 0)
            {
                throw new Exception("No Pipeline Components");
            }
            var app = ReturnDone;
            for (int i = _components.Count - 1; i >= 0; i--)
            {
                var component = _components[i];
                component.Connect(app);
                app = component.Execute;
            }
            return app;
        }



        public void Setup(Env hostEnvironment)
        {
            if (_components.Count == 0)
            {
                throw new Exception("No Pipeline Components");
            }
            for (int i = 0; i < _components.Count; i++)
            {
                _components[i].Setup(hostEnvironment);
            }
        }

        public IPipeline Use(IPipelineComponent component)
        {
            _components.Add(component);
            return this;
        }

        public IPipeline Use(MiddlewareFunc middleware, SetupAction setup = null)
        {
            _components.Add(new MiddleWareDelegateComponent(middleware, setup));
            return this;
        }

        public void Use(AppFunc app, SetupAction setup = null)
        {
            _components.Add(new MiddleWareDelegateComponent((env, next) => app(env), setup));
        }
    }                                                                                                        
}
