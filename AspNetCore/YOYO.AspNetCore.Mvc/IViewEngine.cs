using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YOYO.Owin;

namespace YOYO.Mvc
{
    public interface IViewEngine
    {
        string ExtensionName { get; }
        string RenderView(IOwinContext context, string viewName, object model , DynamicDictionary viewbag);

        Task<string> RenderViewAsync(IOwinContext context, string viewName, object model, DynamicDictionary viewbag);

    }
}
