using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

#if NETCOREAPP1_0
using System.Runtime.Loader;
#endif


namespace YOYO.Mvc
{
    public class ApplicationAssemblyLoader
    {
        private static IEnumerable<Type> types = null;
        private static IDictionary<string, Type> mvcControllers = new Dictionary<string, Type>();

        public static void ResolveAssembly(string path)
        {
            DirectoryInfo dir = new DirectoryInfo(path);

            var searchFiles = dir.GetFiles("*.dll", SearchOption.AllDirectories);

            Func<FileInfo, Type[]> loadAssemblyByPathFunc = null;
            //loadAssemblyByPathFunc = AssemblyLoadContext.Default


#if NET451
            loadAssemblyByPathFunc = (fileInfo) => AppDomain.CurrentDomain.Load(
                                                        AssemblyName.GetAssemblyName(fileInfo.FullName)
                                                   ).GetTypes();

#endif

#if NETCOREAPP1_0
            loadAssemblyByPathFunc = (fileInfo) => AssemblyLoadContext.Default
                                                       .LoadFromAssemblyPath(fileInfo.FullName).GetTypes();
            
#endif


            var TypeList = searchFiles.SelectMany(file => loadAssemblyByPathFunc(file) );

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
             types.Where(t=> type.GetTypeInfo().IsAssignableFrom(t)  && !t.GetTypeInfo().IsInterface );

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
