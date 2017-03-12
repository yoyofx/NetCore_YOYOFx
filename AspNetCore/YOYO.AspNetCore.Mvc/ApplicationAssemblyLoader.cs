using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

#if NETCOREAPP1_0 || NETSTANDARD1_6
using System.Runtime.Loader;
#endif


namespace YOYO.AspNetCore.Mvc
{
    public class ApplicationAssemblyLoader
    {
        private static IEnumerable<Type> types = null;
        private static IDictionary<string, Type> mvcControllers = new Dictionary<string, Type>();
        private static List<Assembly> _assemblies = new List<Assembly>(100);
        public static void ResolveAssembly(string path)
        {
            DirectoryInfo dir = new DirectoryInfo(path);

            var searchFiles = dir.GetFiles("*.*", SearchOption .TopDirectoryOnly).
                                            Where(f => f.Name.EndsWith(".exe") || f.Name.EndsWith(".dll"));


            var TypeList = searchFiles.SelectMany(file => getAssemblyofTypes(loadAssembly(file)) ).ToList();

            types = TypeList;

            var query = from type in TypeList
                        where type!=null && type.GetTypeInfo().IsSubclassOf(typeof(Controller))
                        select type;

            

            foreach (var t in query)
            {
                if (!mvcControllers.ContainsKey(t.Name))
                    mvcControllers.Add(t.Name, t);
            }


        }

        private static Type[] getAssemblyofTypes(Assembly assembly)
        {
            Type[] ret = new Type[0];
            try
            {
                if (assembly != null)
                {
                    ret = assembly?.GetTypes();
                    _assemblies.Add(assembly);
                }
            }
            catch{}

            return ret;
        }


        /// <summary>
        /// 加载程序集
        /// </summary>
        /// <param name="fileInfo"></param>
        /// <returns></returns>
        private static Assembly loadAssembly(FileInfo fileInfo)
        {
            try
            {
#if NET451
                return AppDomain.CurrentDomain.Load(
                    AssemblyName.GetAssemblyName(fileInfo.FullName)
                );
#else
                string assemblyName = fileInfo.Name.Replace(".dll","").Replace(".exe","");
                return Assembly.Load(new AssemblyName(assemblyName));
#endif
            }
            catch {}
            return null;
        }


        public static IEnumerable<Type> TypesOf(Type type)
        {
            var returnTypes =
             types.Where(t=> type.GetTypeInfo().IsAssignableFrom(t)  && !t.GetTypeInfo().IsInterface );

            return returnTypes;

        }

        public static IEnumerable<Type> GetLoadedTypes()
        {
            return types;
        }

        public static List<Assembly> GetLoadedAssemblies()
        {
            return _assemblies;
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
