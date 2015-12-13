using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Collections.Concurrent;

namespace YOYO.Mvc.ActionRuntime
{
	public class ActionRuntimeManager: IDisposable
    {
		IDictionary<string,IActionRuntimeProvider> ca = new ConcurrentDictionary<string,IActionRuntimeProvider>();


        public ActionRuntimeManager()
        {
            RuntimeProviders = new List<IActionRuntimeProvider>();
        }

        public List<IActionRuntimeProvider> RuntimeProviders { private set; get; }

		public IActionRuntimeProvider FindRuntimeByName(string name)
		{
			IActionRuntimeProvider provider = null;
			ca.TryGetValue (name, out provider);
			return provider;
		}


        public void LoadRuntimeFileSystem(string path)
        {
            if (RuntimeProviders.Count == 0)
                RuntimeProviders.Add(new DotnetActionRuntimeProvider());

            foreach(var runtime in RuntimeProviders)
            {
                runtime.LoadRuntime(path);
				foreach (string controllerName in runtime.GetControllerNames()) {
					ca.Add (controllerName, runtime);
				}

            }

        }


		public void Dispose ()
		{
			ca.Clear ();
		}


    }
}
