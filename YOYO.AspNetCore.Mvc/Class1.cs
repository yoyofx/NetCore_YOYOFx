using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Reflection;
//using System.Runtime.Loader;
namespace YOYO.AspNetCore.Mvc
{
    // This project can output the Class library as a NuGet Package.
    // To enable this option, right-click on the project and select the Properties menu item. In the Build tab select "Produce outputs on build".
    public class Class1
    {
        public Class1()
        {


            //TypeInfo t = typeof(int).GetTypeInfo();

            //t.GetMethod("");

            //var assembly = AssemblyLoadContext.Default.LoadFromAssemblyPath();


            //PlatformServices.Default.Application.ApplicationBasePath;

#if net451
            TypeInfo t = typeof(int).GetTypeInfo();

            t.GetMethod("");
#else
            string s = "efwefwefwefwefwfe";
#endif




        }
    }
}
