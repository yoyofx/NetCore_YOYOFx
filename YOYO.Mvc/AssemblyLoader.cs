using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace YOYO.Mvc
{
    public class AssemblyLoader
    {

        private static IDictionary<string, Type> mvcControllers = new Dictionary<string, Type>();

        public static void ResolveAssembly()
        {
            DirectoryInfo dir = new DirectoryInfo(HostingEnvronment.GetMapPath("/bin"));
            if (!dir.Exists) dir = new DirectoryInfo(HostingEnvronment.GetMapPath("/"));
            var searchFiles = dir.GetFiles("*.dll", SearchOption.AllDirectories);
            Console.WriteLine(dir.Name);
            var TypeList = searchFiles.SelectMany(f => AppDomain.CurrentDomain.Load(AssemblyName.GetAssemblyName(f.FullName)).GetTypes());

            var query = from type in TypeList
                        where type.IsSubclassOf(typeof(Controller))
                        select type;

            Console.WriteLine(string.Join(",", searchFiles.Select(f => f.Name).ToArray()));

            foreach (var t in query)
            {
                Console.WriteLine(t.Name);
                if (!mvcControllers.ContainsKey(t.Name))
                    mvcControllers.Add(t.Name, t);
            }


        }


        public static Type FindControllerTypeByName(string controllerName)
        {
            Type controllertype = null;
            mvcControllers.TryGetValue(controllerName, out controllertype);

            return controllertype;

        }




    }
}
