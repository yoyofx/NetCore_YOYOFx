using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace YOYO.AspNetCore.Owin
{
    public class Class1
    {

        static void main()
        {
            //TypeInfo t = typeof(int).GetTypeInfo();

            //t.GetMethod("");

            //var assembly = AssemblyLoadContext.Default.;


            //PlatformServices.Default.Application.ApplicationBasePath;


            string hello;
#if NET451
            hello= "hello dotnet 4.5.1";
#endif

#if NETCOREAPP1_0
            hello = "hello dotnet core";
#endif




        }

    }
}
