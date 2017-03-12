using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YOYO.AspNetCore.Mvc.ActionRuntime;

namespace YOYO.AspNetCore.Mvc
{
    public class DefaultBootstrapper : IYOYOBootstrapper
    {
        public DefaultBootstrapper()
        {
            RuntimeManager = new ActionRuntimeManager();
        }


        public ActionRuntimeManager RuntimeManager { private set; get; }
        public virtual void Initialise()
        {
            ApplicationAssemblyLoader.ResolveAssembly(this.GetRootPath());
            RuntimeManager.LoadRuntimeFileSystem(this.GetRootPath());
            ViewEngineFactory.LoadViewEngine();
        }

        public virtual Task InitialiseAsync()
        {
            return Task.Factory.StartNew(() => Initialise());
        }


        public virtual string GetRootPath()
        {
            return HostingEnvronment.GetRootPath();
        }

        public IEnumerable<Type> ViewEngines
        {
            get
            {
                return ApplicationAssemblyLoader.TypesOf(typeof(IViewEngine));
            }

        }

    }
}
