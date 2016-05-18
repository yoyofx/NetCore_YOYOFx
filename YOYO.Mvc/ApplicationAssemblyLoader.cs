using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace YOYO.Mvc
{
    public class ApplicationAssemblyLoader
    {
        private static IEnumerable<Type> types = null;
        private static IDictionary<string, Type> mvcControllers = new Dictionary<string, Type>();

        public static void ResolveAssembly(string path)
        {
            DirectoryInfo dir = new DirectoryInfo(path);
            //if (!dir.Exists) dir = new DirectoryInfo(HostingEnvronment.GetMapPath("/"));
            var searchFiles = dir.GetFiles("*.dll", SearchOption.AllDirectories);
            string ss = string.Empty;


            var TypeList = searchFiles.SelectMany(f => AppDomain.CurrentDomain.Load(AssemblyName.GetAssemblyName(f.FullName)).GetTypes());

            types = TypeList;


            var query = from type in TypeList
                        where type.GetTypeInfo().IsSubclassOf(typeof(Controller))
                        select type;

            
            

            foreach (var t in query)
            {
                if (!mvcControllers.ContainsKey(t.Name))
                    mvcControllers.Add(t.Name, t);
            }


        }

        public static IEnumerable<Type> TypesOf(Type type)
        {
            var returnTypes =
             types.Where(t=> type.IsAssignableFrom(t)  && !t.GetTypeInfo().IsInterface );

            return returnTypes;

        }


        public static string[] GetControllerNames()
		{
			return mvcControllers.Keys.ToArray ();
		}


        public static Type FindControllerTypeByName(string controllerName)
        {
            Type controllertype = null;
            mvcControllers.TryGetValue(controllerName, out controllertype);

            return controllertype;

        }




    }
}
