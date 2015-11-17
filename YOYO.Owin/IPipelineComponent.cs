using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YOYO.Owin
{
    using Env = IDictionary<string, object>;
    using AppFunc = Func< //
        IDictionary<string, object>, // owin request environment
        Task // completion signal
        >;

    public interface IPipelineComponent
    {
        void Connect(AppFunc next);

        Task Execute(Env requestEnvironment);

        void Setup(Env hostEnvironment);
    }
}
