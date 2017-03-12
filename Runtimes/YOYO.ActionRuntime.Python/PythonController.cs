using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Scripting.Hosting;
using YOYO.Owin;

namespace YOYO.ActionRuntime.Python
{
    public class PythonController : IDisposable
    {
        public string Name { set; get; }
        public ScriptEngine Engine {private set; get; }
        private CompiledCode _compiledCode = null;


        public PythonController(ScriptEngine engine,string path)
        {
            this.Name = System.IO.Path.GetFileNameWithoutExtension(path);
            this.Engine = engine;
            var scriptSource = engine.CreateScriptSourceFromFile(path, Encoding.UTF8, Microsoft.Scripting.SourceCodeKind.File);
            _compiledCode = scriptSource.Compile();
           
        }

        public dynamic ActionInvoke(string actionName,dynamic p)
        {
            var scope = this.Engine.CreateScope();
            this.Engine.Runtime.LoadAssembly(typeof(IOwinRequest).Assembly);
            dynamic funcResult = null;
            try {
                _compiledCode.Execute(scope);
                dynamic actionInvokerFunc = scope.GetVariable(actionName);
                funcResult =  this.Engine.Operations.Invoke(actionInvokerFunc, p);

               // var funcType = ((object)actionInvokerFunc).GetType();
               //var argNames =  funcType.GetProperty("ArgNames", BindingFlags.Instance | BindingFlags.NonPublic);
               // var arguments = argNames.GetValue(actionInvokerFunc, null) as string[];

                //funcResult = actionInvokerFunc(p);
            }
            catch(Exception ex){
               throw new NullReferenceException(string.Format("Not Found Action Name by {0} , Exception:", actionName ,ex.ToString()));
            }
            return funcResult;
        }

        public void Dispose()
        {
            _compiledCode = null;
        }
    }
}
