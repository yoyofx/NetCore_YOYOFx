using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YOYO.Mvc.Reflection;
using System.Reflection;
using YOYO.Owin;
using YOYO.Mvc.Extensions;

namespace YOYO.Mvc.ActionRuntime
{
    public class DotnetActionRuntimeProvider : IActionRuntimeProvider

    {
        private static ConcurrentDictionary<MethodInfo, IDynamicMethodInvoker> actionInvokerCache = new ConcurrentDictionary<MethodInfo, IDynamicMethodInvoker>();

		public string Name{ get{ return "dotnet"; } }

		public object ExecuteAsync(string controllerName,string actionName,IOwinContext context)
		{
			var controllerType = ApplicationAssemblyLoader.FindControllerTypeByName(controllerName);
			if (controllerType == null) throw new NullReferenceException("Not Found Controller Name by" + controllerName);

			var controller = (Controller)Activator.CreateInstance(controllerType);
            var pi = controllerType.GetProperty("Context",BindingFlags.NonPublic | BindingFlags.Public  | BindingFlags.Instance | BindingFlags.Static);
            pi.SetValue(controller, context);
			var actionMethodInfo = controllerType.GetMethod(actionName);
			if (actionMethodInfo == null) throw new NullReferenceException("Not Found Action Name by" + actionName);

			IDynamicMethodInvoker invoker = null;
			if (!actionInvokerCache.TryGetValue(actionMethodInfo, out invoker))
			{
				invoker = new DynamicMethodInvoker(actionMethodInfo);
				actionInvokerCache.TryAdd(actionMethodInfo, invoker);
			}

           var parameterInfoList = actionMethodInfo.GetParameters();

           var actionParams = parameterInfoList.ToActionParameters();

            var paramValues = ActionRuntimeParameter.GetValuesByRequest(actionParams, context.Request);

			object result = invoker.Invoke(controller, paramValues.ToArray());

			return result;
		}


      


		public string[] GetControllerNames()
		{

			return ApplicationAssemblyLoader.GetControllerNames();
		}



        public void LoadRuntime(string path)
        {
            //ApplicationAssemblyLoader.ResolveAssembly(path);
        }
    }
}
