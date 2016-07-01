using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YOYO.Mvc.ActionRuntime;

namespace YOYO.Mvc
{
    public interface IYOYOBootstrapper
    {
        ActionRuntimeManager RuntimeManager { get; }
        void Initialise();


        IEnumerable<Type> ViewEngines { get; }
    }
}
