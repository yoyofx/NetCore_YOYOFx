using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OwinHost
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


    internal interface IPipeline
    {
        AppFunc Build();

        void Setup(Env hostEnvironment);

        void Use(AppFunc app);

        IPipeline Use(MiddlewareFunc middleware);

        IPipeline Use(IPipelineComponent component);
    }
}
