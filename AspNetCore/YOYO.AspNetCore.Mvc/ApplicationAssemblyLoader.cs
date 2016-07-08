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


namespace YOYO.Mvc
{
    public class ApplicationAssemblyLoader
    {
        private static IEnumerable<Type> types = null;
        private static IDictionary<string, Type> mvcControllers = new Dictionary<string, Type>();

        public static void ResolveAssembly(string path)
        {
            DirectoryInfo dir = new DirectoryInfo(path);

            var searchFiles = dir.GetFiles("*.*", SearchOption .TopDirectoryOnly).
                                            Where(f => f.Name.EndsWith(".exe") || f.Name.EndsWith(".dll"));

            Func<FileInfo, Type[]> loadAssemblyByPathFunc = null;
            
#if NET451
            loadAssemblyByPathFunc = (fileInfo) => {
                try
                {
                    return AppDomain.CurrentDomain.Load(
                         AssemblyName.GetAssemblyName(fileInfo.FullName)
                    ).GetTypes();
                }
                catch { }
                    return new Type[0] ;
                };

#endif

#if NETCOREAPP1_0 || NETSTANDARD1_6

             loadAssemblyByPathFunc = (fileInfo) => {
                try
                {
                    //return AssemblyLoadContext.Default
                    //          .LoadFromAssemblyPath(fileInfo.FullName).GetTypes();


                    string assemblyName = fileInfo.Name.Replace(".dll","").Replace(".exe","");

                    return Assembly.Load(new AssemblyName(assemblyName)).GetTypes();
                }
                catch{ }
                    return new Type[0];
                };

           
            
#endif


            var TypeList = searchFiles.SelectMany(file => loadAssemblyByPathFunc(file) );

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

        public static IEnumerable<Type> TypesOf(Type type)
        {
            var returnTypes =
             types.Where(t=> type.GetTypeInfo().IsAssignableFrom(t)  && !t.GetTypeInfo().IsInterface );

            return returnTypes;

        }

        public static IEnumerable<Type> GetAllTypes()
        {
            return types;
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
