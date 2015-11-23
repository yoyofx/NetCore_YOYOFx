using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YOYO.Owin.Pipeline
{
    using Env = IDictionary<string, object>;
   
    using SetupAction = Action< //
        IDictionary<string, object> // owin host environment
        >;

    public interface IPipeline
    {
        AppFunc Build();

        void Setup(Env hostEnvironment);

        void Use(AppFunc app, SetupAction setup = null);

        IPipeline Use(MiddlewareFunc middleware, SetupAction setup = null);

        IPipeline Use(IPipelineComponent component);
    }
}
