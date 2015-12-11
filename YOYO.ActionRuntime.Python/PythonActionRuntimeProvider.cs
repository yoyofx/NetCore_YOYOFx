using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YOYO.Mvc.ActionRuntime;

namespace YOYO.ActionRuntime.Python
{
    public class PythonActionRuntimeProvider : IActionRuntimeProvider
    {
        public object ExecuteAsync(string controllerName, string actionName, params object[] parameters)
        {
            throw new NotImplementedException();
        }

        public void LoadRuntime(string path)
        {
            throw new NotImplementedException();
        }
    }
}
