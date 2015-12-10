using System;
using System.Collections.Generic;
using System.Linq;

namespace YOYO.Mvc
{
    public class HostingEnvronment
    {
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

        ///<summary>
        ///支持相对路径的./和../
        ///</summary>
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

    }
}
