using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YOYO.Mvc.ActionRuntime
{
    public interface IActionRuntimeProvider
    {
        void LoadRuntime(string path);
        
        object ExecuteAsync(string controllerName,string actionName,params object[] parameters);


    }
}
