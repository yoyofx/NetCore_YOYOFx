using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YOYO.Mvc.ActionRuntime;
using YOYO.Owin;


namespace YOYO.ActionRuntime.Python
{
    public class PythonActionRuntimeProvider : IActionRuntimeProvider
    {
        public PythonActionRuntimeProvider()
        {
            runtime = new PythonRuntime();
        }

        private PythonRuntime runtime;


        public string Name{ get{ return "python"; } }

		public object ExecuteAsync(string controllerName, string actionName, IOwinContext context)
		{
            var controller = runtime.GetController(controllerName);
            return (object)controller.ActionInvoke(actionName, context.Request);
        }

		public string[] GetControllerNames()
		{
            return runtime.GetControllerNames();
		}


        public void LoadRuntime(string path)
        {
            DirectoryInfo dir = new DirectoryInfo(path);
            var searchFiles = dir.GetFiles("*.py", SearchOption.AllDirectories);
            foreach(var file in searchFiles)
            {
                runtime.AddController(file.FullName);
            }


        }
    }
}
