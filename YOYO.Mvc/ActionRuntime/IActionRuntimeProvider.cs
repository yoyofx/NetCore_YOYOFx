using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YOYO.Owin;

namespace YOYO.Mvc.ActionRuntime
{
    public interface IActionRuntimeProvider
    {
		string Name{ get; }

		string[] GetControllerNames ();

        void LoadRuntime(string path);
        
		object ExecuteAsync (string controllerName, string actionName, IOwinContext context);
    }
}
