using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YOYO.Mvc.ActionRuntime;

namespace YOYO.Mvc
{
    public class DefaultBootstrapper : IYOYOBootstrapper
    {

        public ActionRuntimeManager RuntimeManager { private set; get; }
        public void Initialise()
        {
            RuntimeManager = new ActionRuntimeManager();

            RuntimeManager.LoadRuntimeFileSystem(this.GetRootPath());

        }

        public virtual string GetRootPath()
        {
            return HostingEnvronment.GetRootPath();
        }



    }
}
