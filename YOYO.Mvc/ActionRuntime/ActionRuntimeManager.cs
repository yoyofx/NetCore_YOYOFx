using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YOYO.Mvc.ActionRuntime
{
    public class ActionRuntimeManager
    {

        public ActionRuntimeManager()
        {
            RuntimeProviders = new List<IActionRuntimeProvider>();
        }

        public List<IActionRuntimeProvider> RuntimeProviders { private set; get; }



        public void LoadRuntimeFileSystem(string path)
        {
            if (RuntimeProviders.Count == 0)
                RuntimeProviders.Add(new DotnetActionRuntimeProvider());

            foreach(var runtime in RuntimeProviders)
            {
                runtime.LoadRuntime(path);
            }

        }


    }
}
