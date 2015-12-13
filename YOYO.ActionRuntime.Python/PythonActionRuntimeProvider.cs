using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YOYO.Mvc.ActionRuntime;
using Microsoft.Scripting;
using Microsoft.Scripting.Hosting;
using Microsoft.Scripting.Runtime;
using YOYO.Owin;


namespace YOYO.ActionRuntime.Python
{
    public class PythonActionRuntimeProvider : IActionRuntimeProvider
    {
 
		public string Name{ get{ return "python"; } }

		public object ExecuteAsync(string controllerName, string actionName, IOwinContext context)
		{

			throw new NotImplementedException();
		}

		public string[] GetControllerNames()
		{
			return null;
		}


        public void LoadRuntime(string path)
        {
            throw new NotImplementedException();
        }
    }
}
