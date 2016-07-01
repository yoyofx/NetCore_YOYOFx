using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YOYO.Mvc
{
    public class ViewEngineFactory
    {
        private static IDictionary<string, IViewEngine> viewEngineCache = new ConcurrentDictionary<string, IViewEngine>();
        public static void LoadViewEngine()
        {
            var viewEngineTypes = ApplicationAssemblyLoader.TypesOf(typeof(IViewEngine));

            foreach (var viewEngineType in viewEngineTypes)
            {
                var viewEngine = (IViewEngine)Activator.CreateInstance(viewEngineType);
                viewEngineCache.Add(viewEngine.ExtensionName, viewEngine);

            }
        }

        public static IViewEngine GetViewEngine(string extension)
        {
            IViewEngine engine = null;
            viewEngineCache.TryGetValue(extension, out engine);

            return engine;

        }

    }
}
