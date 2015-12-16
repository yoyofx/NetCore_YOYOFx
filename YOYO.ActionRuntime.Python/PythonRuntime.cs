using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Scripting.Hosting;

namespace YOYO.ActionRuntime.Python
{
    public class PythonRuntime
    {
        private ScriptEngine _engine = null;
        private IDictionary<string, PythonController> _controllers = new ConcurrentDictionary<string, PythonController>();
        public PythonRuntime()
        {
            _engine = IronPython.Hosting.Python.CreateEngine();
        }
      
        public PythonController GetController(string name)
        {
            PythonController controller = null;
            _controllers.TryGetValue(name, out controller);
            return controller;
        }

        public string[] GetControllerNames()
        {
            return _controllers.Keys.ToArray();
        }



        public void AddController(string path)
        {
             string name = System.IO.Path.GetFileNameWithoutExtension(path);
            if (_controllers.ContainsKey(name))
                throw new InvalidOperationException("controller is contain");

            var controller = new PythonController(this._engine, path);
            _controllers.Add(name,controller);
        }

        public void ReloadController(string path)
        {
            string name = System.IO.Path.GetFileNameWithoutExtension(path);
            if (_controllers.ContainsKey(name))
            {
                //update
                _controllers[name] = new PythonController(this._engine, path);
            }
            else
            {
                //add
                AddController(path);

            }

        }

        public void RemoveController(string path)
        {
            string name = System.IO.Path.GetFileNameWithoutExtension(path);
            if (_controllers.ContainsKey(name))
            {
                _controllers.Remove(name);
            }
        }



    }


}
