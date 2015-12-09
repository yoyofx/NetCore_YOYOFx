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

        private static IDictionary<string, Type> mvcControllers = null;

       
        /// <summary>
        /// 获得当前绝对路径，同时兼容windows和linux（系统自带的都不兼容）。
        /// </summary>
        /// <param name="strPath">指定的路径，支持/|./|../分割</param>
        /// <returns>绝对路径，不带/后缀</returns>
        public static string GetMapPath(string strPath)
        {
            string rootPath = (AppDomain.CurrentDomain.GetData(".appPath") as string) ?? Environment.CurrentDirectory;

            if (strPath == null)
            {
                return rootPath;
            }
            else
            {
                List<string> prePath = rootPath.Split(new char[] { '/', '\\' }, StringSplitOptions.RemoveEmptyEntries).ToList();
                List<string> srcPath = strPath.Split(new char[] { '/', '\\' }, StringSplitOptions.RemoveEmptyEntries).ToList();
                ComputePath(prePath, srcPath);
                if (prePath.Count > 0 && prePath[0].Contains(":"))//windows
                {
                    if (prePath.Count == 1)
                    {
                        return prePath[0] + "/";
                    }
                    else
                    {
                        return String.Join("/", prePath);
                    }
                }
                else//linux
                {
                    return "/" + String.Join("/", prePath);
                }
            }
        }

        private static void ComputePath(List<string> prePath, List<string> srcPath)
        {
            var precount = prePath.Count;
            foreach (string src in srcPath)
            {
                if (src == "..")
                {
                    if (precount > 1 || (precount == 1 && !prePath[0].Contains(":")))
                    {
                        prePath.RemoveAt(--precount);
                    }
                }
                else if (src != ".")
                {
                    prePath.Add(src);
                    precount++;
                }
            }
        }

        public static void ResolveAssembly()
        {
            DirectoryInfo dir = new DirectoryInfo(GetMapPath("/bin"));
            if (!dir.Exists) dir = new DirectoryInfo(GetMapPath("/"));
            var searchFiles = dir.GetFiles("*.dll", SearchOption.AllDirectories);

           var TypeList =  searchFiles.SelectMany(f => AppDomain.CurrentDomain.Load(AssemblyName.GetAssemblyName(f.FullName)).GetTypes());

            var query = from type in TypeList
                                where type.IsSubclassOf(typeof(Controller))
                                select type;

            mvcControllers = query.ToDictionary(kv => kv.Name);


        }


        public static Type FindControllerTypeByName(string controllerName)
        {
            Type controllertype = null;
            mvcControllers.TryGetValue(controllerName, out controllertype);

            return controllertype;

        }




    }
}
